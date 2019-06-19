using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RegisterCompanyAndAuth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegisterCompanyAndAuth.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder => builder.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials()
                );
            });
        }

        public static void ConfigureIISIntegration(this IServiceCollection services)
        {
            services.Configure<IISOptions>(options =>
            {

            });
        }

        public static void ConfigurePostgreSQL(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<CompaniesContext>(options => options
                    .UseNpgsql(config.GetConnectionString("PostgresContext")), ServiceLifetime.Singleton).BuildServiceProvider();

        }

        public static void ConfigureServices(this IServiceCollection services)
        {
            
        }

        public static void ConfigureRepositories(this IServiceCollection services)
        {

        }

        //public static void ConfigureSwaggerDocs(this IServiceCollection services)
        //{
        //    services.AddSwaggerGen(options =>
        //    {
        //        options.DescribeAllEnumsAsStrings();
        //        options.DescribeAllParametersInCamelCase();
        //        options.SwaggerDoc("v1", new Info
        //        {
        //            Title = "API Docs",
        //            Version = "v1",
        //            Description = "API Docs created with Swagger",
        //            TermsOfService = "None",

        //            Contact = new Contact
        //            {
        //                Name = "Digitaldoc",
        //                Email = "digitaldocbr@digitaldoc.com.br",
        //                Url = "digitaldoc.com.br"
        //            }

        //        });
        //        // options.IncludeXmlComments(Path.Combine(PlatformServices.Default.Application.ApplicationBasePath, "Eatosv3.WebApi.Docs.xml"));
        //    });

        //}
    }
}
