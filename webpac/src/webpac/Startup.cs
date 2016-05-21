using System;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using webpac.Services;
using webpac.Filters;
using webpac.Interfaces;
using System.Security.Cryptography;
using System.IdentityModel.Tokens;
using TokenAuthExampleWebApplication;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Authentication.JwtBearer;
using System.Security.Claims;
using Swashbuckle.SwaggerGen;
using webpac.Swagger;
using Microsoft.AspNet.Cors.Infrastructure;

namespace webpac
{
    /// <summary>
    /// http://benfoster.io/blog/generating-hypermedia-links-in-aspnet-web-api
    /// http://www.codeproject.com/Articles/1005145/DNVM-DNX-and-DNU-Understanding-the-ASP-NET-Runtime
    /// https://libraries.io/nuget/Microsoft.AspNet.SignalR.Server/3.0.0-beta5 
    /// </summary>
    public class Startup
    {
        const string TokenAudience = "ExampleAudience";
        const string TokenIssuer = "ExampleIssuer";
        private RsaSecurityKey key;
        private TokenAuthOptions tokenOptions;


        public Startup(IHostingEnvironment env)
        {
            // Set up configuration sources.
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; set; }

        /// <summary>
        /// AddMvcCore: https://manuel-rauber.com/2016/02/15/back-to-the-roots-creating-thin-webapis-using-the-core-of-aspnet-core/
        /// https://github.com/aspnet-contrib/AspNet.Security.OpenIdConnect.Samples/blob/master/samples/Mvc/Mvc.Server/Startup.cs
        /// </summary>
        /// <param name="services"></param>
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(Microsoft.Extensions.DependencyInjection.IServiceCollection services)
        {
            //ad corse
            AddCorse(services);

            //add and configure swagger
            services.AddSwaggerGen();
            services.ConfigureSwaggerDocument(options =>
            {
                options.SingleApiVersion(new Info
                {
                    Version = "v1",
                    Title = "webpac",
                    Description = "a api to access plc data in a structured way"
                });
                options.OperationFilter(new AuthorizationHeaderParameterOperationFilter());
            });

            //add filter to log Actions
            services.AddScoped<ActionLoggerFilter>();

            //add the custom services
            services.AddSingleton<IRuntimeCompilerService, RuntimeCompilerService>();
            services.AddSingleton<IMappingService, MappingService>();
            services.AddSingleton<IAuthenticationService, AuthenticationService>();
            AddAuthentication(services);

            //add signal r usage
            services.AddSignalR();

            // Add framework services.
            services.AddMvc();
        }



        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app,
                                IHostingEnvironment env,
                                ILoggerFactory loggerFactory,
                                IMappingService mappingService,
                                IRuntimeCompilerService runtimeCompilerService,
                                IAuthenticationService authService
            )
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            runtimeCompilerService.Configure(Configuration.GetSection("RuntimeCompiler"));
            runtimeCompilerService.Init();

            mappingService.Configure(Configuration.GetSection("Plc"));
            mappingService.Init();

            authService.Configure(Configuration.GetSection("Auth"));
            authService.Init();

            app.UseJwtBearerAuthentication(options =>
            {
                // Basic settings - signing key to validate with, audience and issuer.
                options.TokenValidationParameters.IssuerSigningKey = key;
                options.TokenValidationParameters.ValidAudience = tokenOptions.Audience;
                options.TokenValidationParameters.ValidIssuer = tokenOptions.Issuer;

                // When receiving a token, check that we've signed it.
                options.TokenValidationParameters.ValidateSignature = true;

                // When receiving a token, check that it is still valid.
                options.TokenValidationParameters.ValidateLifetime = true;

                // This defines the maximum allowable clock skew - i.e. provides a tolerance on the token expiry time 
                // when validating the lifetime. As we're creating the tokens locally and validating them on the same 
                // machines which should have synchronized time, this can be set to zero. Where external tokens are
                // used, some leeway here could be useful.
                options.TokenValidationParameters.ClockSkew = TimeSpan.FromMinutes(0);
            });

            if (env.IsDevelopment())
            {
                app.UseRuntimeInfoPage(); // default path is /runtimeinfo
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("corsGlobalPolicy");

            app.UseSwaggerGen();

            app.UseSwaggerUi();

            //app.UseWelcomePage();

            //app.UseIISPlatformHandler();

            //app.UseStaticFiles();

            //is required to use controllers
            app.UseMvc();

            app.UseSignalR();
        }




        // Entry point for the application.
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);

        private void AddAuthentication(IServiceCollection services)
        {
            // *** CHANGE THIS FOR PRODUCTION USE ***
            // Here, we're generating a random key to sign tokens - obviously this means
            // that each time the app is started the key will change, and multiple servers 
            // all have different keys. This should be changed to load a key from a file 
            // securely delivered to your application, controlled by configuration.
            //
            // See the RSAKeyUtils.GetKeyParameters method for an example of loading from
            // a JSON file.
            RSAParameters keyParams = RSAKeyUtils.GetRandomKey();

            // Create the key, and a set of token options to record signing credentials 
            // using that key, along with the other parameters we will need in the 
            // token controller.
            key = new RsaSecurityKey(keyParams);
            tokenOptions = new TokenAuthOptions()
            {
                Audience = TokenAudience,
                Issuer = TokenIssuer,
                SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.RsaSha256Signature)
            };

            // Save the token options into an instance so they're accessible to the 
            // controller.
            services.AddInstance(tokenOptions);


            ConfigureAuthenticationService(services);
        }

        /// <summary>
        /// Add Policies for the authorization and us Bearer for Authentication
        /// </summary>
        /// <param name="services"></param>
        private static void ConfigureAuthenticationService(IServiceCollection services)
        {
            services.AddAuthentication(config =>
            {
                config.SignInScheme = JwtBearerDefaults.AuthenticationScheme;
            });
            services.AddAuthorization(options =>
            {
                options.AddPolicy("AdministrationPolicy", new AuthorizationPolicyBuilder()
                    .RequireClaim(ClaimTypes.Role, "Admin")
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme‌​)
                    .RequireAuthenticatedUser()
                    .Build());

                options.AddPolicy("ReadWritePolicy", new AuthorizationPolicyBuilder()
                    .RequireClaim(ClaimTypes.Role, "ReadWrite", "Admin")
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme‌​)
                    .RequireAuthenticatedUser()
                    .Build());

                options.AddPolicy("ReadOnlyPolicy", new AuthorizationPolicyBuilder()
                    .RequireClaim(ClaimTypes.Role, "ReadOnly", "ReadWrite", "Admin")
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme‌​)
                    .RequireAuthenticatedUser()
                    .Build());
            });
        }

        private static void AddCorse(IServiceCollection services)
        {
            var policy = new CorsPolicy();
            policy.Headers.Add("*");
            policy.Methods.Add("*");
            policy.Origins.Add("*");
            policy.SupportsCredentials = true;

            services.AddCors(x => x.AddPolicy("corsGlobalPolicy", policy));
        }

    }
}
