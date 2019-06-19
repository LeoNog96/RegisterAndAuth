using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RegisterCompanyAndAuth.Models;
using RegisterCompanyAndAuth.Repositories;
using RegisterCompanyAndAuth.Repositories.Interfaces;
using RegisterCompanyAndAuth.Services;
using RegisterCompanyAndAuth.Services.Interfaces;
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
            services.AddScoped<IRegisterService, RegisterService>();
        }

        public static void ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUsersRepository, UsersRepository>();
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
        //                Name = "",
        //                Email = "",
        //                Url = ""
        //            }

        //        });
        //        // options.IncludeXmlComments(Path.Combine(PlatformServices.Default.Application.ApplicationBasePath, "Eatosv3.WebApi.Docs.xml"));
        //    });

        //}
    }
}
