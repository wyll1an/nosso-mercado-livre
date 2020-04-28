using System;
using System.IO;
using System.Reflection;
using System.Text;
using AutoMapper;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using NossoMercadoLivreAPI.Domain.Const;
using NossoMercadoLivreAPI.Infra.CrossCutting.IoC;
using NossoMercadoLivreAPI.Service.AutoMapper;
using NossoMercadoLivreAPI.Service.Exceptions;
using Microsoft.EntityFrameworkCore;
using NossoMercadoLivreAPI.Infra.Data.Context;

namespace NossoMercadoLivreAPI.Application
{
    public class Startup
    {
        public Startup(IWebHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
              .SetBasePath(env.ContentRootPath)
              .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
              .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
              .AddEnvironmentVariables();
            
            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            new DependencyInjection(services).RegisterServices();

            services.AddAutoMapper(typeof(AutoMapperConfig));

            services.AddMvc(config => config.Filters.Add(typeof(CustomExceptionFilter)))
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
                .AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<Startup>());

            ConfigDatabase(services);
            SwaggerConfigGen(services);
            CorsConfig(services);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseSwagger();
            SwaggerConfigUI(app);

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors(Policy.AllowAll);
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        #region Métodos privados

        private void SwaggerConfigGen(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Swagger XML Api NossoMercadoLivreAPI",
                    Version = "v1",
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

                c.IncludeXmlComments(xmlPath);
            });
        }

        private void SwaggerConfigUI(IApplicationBuilder app)
        {
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger XML Api NossoMercadoLivreAPI v1");
            });
        }

        private void CorsConfig(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(Policy.AllowAll, p =>
                {
                    p.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });
        }

        private void ConfigDatabase(IServiceCollection services)
        {
            services.AddDbContext<ContextDb>(opt =>
                opt.UseNpgsql(Configuration.GetConnectionString("NossoMercadoLivreAPI_DB"))
            );
        }
        #endregion
    }
}
