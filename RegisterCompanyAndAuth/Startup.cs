using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RegisterCompanyAndAuth.Extensions;

namespace RegisterCompanyAndAuth
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.ConfigurePostgreSQL(Configuration);

            services.ConfigureCors();

            services.ConfigureIISIntegration();

            //services.ConfigureLoggerService();

            //services.ConfigureRepositories();

            services.ConfigureServices();

            //services.ConfigureSwaggerDocs();

            services.AddMvc();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            //loggerFactory.AddNLog();
            //env.ConfigureNLog("NLog.config");

            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //    app.UseDatabaseErrorPage();
            //    app.UseBrowserLink();
            //}

            //app.UseHttpStatusCodeExceptionMiddleware();

            app.UseCors("CorsPolicy");

            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.All
            });

            app.UseStaticFiles();

            //app.UseSwagger(options => options.RouteTemplate = "docs/{documentName}/swagger.json");
            //app.UseSwaggerUI(options =>
            //{
            //    options.SwaggerEndpoint("/docs/v1/swagger.json", "API Docs v1");
            //    options.RoutePrefix = "docs";
            //});

            app.UseMvc();
        }
    }
}
