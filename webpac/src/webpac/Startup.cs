using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using webpac.Interfaces;
using webpac.Filters;
using webpac.Services;
using webpac.Auth;
using webpac.Swagger;
using System.IO;
using System;
using NLog.Extensions.Logging;

namespace webpac
{
    public class Startup
    {

        public static void Main(string[] args)
        {
            try
            {
                var host = new WebHostBuilder()
                    .UseKestrel()
                    .UseContentRoot(Directory.GetCurrentDirectory())
                    .UseIISIntegration()
                    .UseStartup<Startup>()
                    .Build();

                host.Run();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();

            //add and configure swagger
            services.AddSwaggerGen();
            services.ConfigureSwaggerGen(options =>
            {
                options.SingleApiVersion(new Swashbuckle.SwaggerGen.Generator.Info
                {
                    Version = "v1",
                    Title = "webpac",
                    Description = "a api to access plc data in a structured way"
                });
                options.OperationFilter<AuthorizationHeaderParameterOperationFilter>();
            });

            //add filters
            services.AddScoped<ActionLoggerFilterAttribute>();
            services.AddScoped<WebPacExceptionFilterAttribute>();

            //add the custom services
            services.AddSingleton<IRuntimeCompilerService, RuntimeCompilerService>();
            services.AddSingleton<IMappingService, MappingService>();
            services.AddSingleton<IAuthenticationService, AuthenticationService>();
            services.AddSingleton<IRelayService, RelayService>();

            //configure the webpac auth
            services.AddWebPacAuthentication(Configuration.GetSection("Auth")?.Get<string>("KeyFile"));

            //add signal r usage
            services.AddSignalR(options =>
            {
                options.Hubs.EnableDetailedErrors = true;
            });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app,
                                IHostingEnvironment env,
                                ILoggerFactory loggerFactory,
                                IMappingService mappingService,
                                IRuntimeCompilerService runtimeCompilerService,
                                IAuthenticationService authService,
                                IRelayService relayService
            )
        {
            var globalConfig = Configuration.GetSection("Global");
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (globalConfig.Get("UseLogFiles", true))
            {
                loggerFactory.AddNLog();
                env.ConfigureNLog("nlog.config");
            }

            runtimeCompilerService.Configure(Configuration.GetSection("RuntimeCompiler"));
            runtimeCompilerService.Init();

            mappingService.Configure(Configuration.GetSection("Plc"));
            mappingService.Init();

            authService.Configure(Configuration.GetSection("Auth"));
            authService.Init();

            app.UseWebPackAuth();

            app.UseCors(options =>
                     {
                         options.AllowAnyHeader();
                         options.AllowAnyMethod();
                         options.AllowAnyOrigin();
                         options.AllowCredentials();
                     });


            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            
            if (globalConfig.Get("UseSignalR", true))
            {
                relayService.Init();

                if ( globalConfig.Get("UseWebSockets", true))
                    app.UseWebSockets();
                app.UseSignalR();
            }


            app.UseMvc();

            if (globalConfig.Get("UseSwagger", true))
            {
                app.UseSwaggerGen();
                app.UseSwaggerUi();
            }
        }

    }
}
