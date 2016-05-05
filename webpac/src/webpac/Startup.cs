﻿using System;
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

namespace webpac
{


    /// <summary>
    /// http://benfoster.io/blog/generating-hypermedia-links-in-aspnet-web-api
    /// http://www.codeproject.com/Articles/1005145/DNVM-DNX-and-DNU-Understanding-the-ASP-NET-Runtime
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
        public void ConfigureServices(IServiceCollection services)
        {
            //var mvcCore = services.AddMvcCore();
            //mvcCore.AddJsonFormatters(options => options.ContractResolver = new CamelCasePropertyNamesContractResolver());
            ConfigureAuthenticationService(services);

            services.AddScoped<ActionLoggerFilter>();
            services.AddSingleton<IMappingService, MappingService>();
            services.AddSingleton<IAuthenticationService, AuthenticationService>();
            AddAuthentication(services);

            // Add framework services.
            services.AddMvc();
        }

        private static void ConfigureAuthenticationService(IServiceCollection services)
        {
            services.AddAuthentication(config =>
            {
                config.SignInScheme = JwtBearerDefaults.AuthenticationScheme;
            });
            services.AddAuthorization(options =>
            {
                options.AddPolicy("AdministrationPolicy", policy =>
                {
                    //policy.RequireRole("Admin");
                    policy.RequireClaim(ClaimTypes.Role, "Admin");
                    policy.AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme);
                    //policy.RequireAuthenticatedUser();
                });
                options.AddPolicy("ReadWritePolicy", policy =>
                {
                    //policy.RequireRole("ReadWrite", "Admin");
                    policy.RequireClaim(ClaimTypes.Role, "ReadWrite");
                    policy.AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme);
                    //policy.RequireAuthenticatedUser();
                });
                options.AddPolicy("ReadOnlyPolicy", policy =>
                {
                    //policy.RequireRole("ReadOnly", "ReadWrite");
                    policy.RequireClaim(ClaimTypes.Role, "ReadOnly");
                    policy.AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme);
                    //policy.RequireAuthenticatedUser();
                });
            });
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app,
                                IHostingEnvironment env,
                                ILoggerFactory loggerFactory,
                                IMappingService mappingService,
                                IAuthenticationService authService)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            mappingService.Configure(Configuration.GetSection("Plc"));
            mappingService.Init();

            authService.Configure(Configuration.GetSection("Auth"));
            authService.Init();
            //app.UseIISPlatformHandler();

            //app.UseStaticFiles();

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
                // machines which should have synchronised time, this can be set to zero. Where external tokens are
                // used, some leeway here could be useful.
                options.TokenValidationParameters.ClockSkew = TimeSpan.FromMinutes(0);
            });

            //is required to use controllers
            app.UseMvc();
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

            // Enable the use of an [Authorize("Bearer")] attribute on methods and classes to protect.
            services.AddAuthorization(auth =>
            {
                auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme‌​)
                    .RequireAuthenticatedUser().Build());
            });
        }


    }
}
