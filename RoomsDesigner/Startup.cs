using FluentValidation.AspNetCore;
using MassTransit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using RoomsDesigner.Api.Authorization;
using RoomsDesigner.Api.Infrastructure;
using RoomsDesigner.Api.Infrastructure.ExceptionHandling;
using RoomsDesigner.Api.Infrastructure.Settings;
using RoomsDesigner.Api.Middleware;
using RoomsDesigner.Application.Services.Implementations.Mapping;
using RoomsDesigner.Infrastructure.EntityFramework;
using System.Text.Json.Serialization;

namespace RoomsDesigner.Api
{
    public class Startup
	{
		private IConfiguration Configuration { get; }

		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllersWithViews();
            // In production, the Angular files will be served from this directory
            services.AddKeycloakAuthentication(Configuration);
            services.AddTransient<IAuthorizationHandler, AgeAuthorizationHandler>();
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            //services.AddAutoMapper(typeof(Program), typeof(CaseMapping));
            //services.AddApplicationDataContext(Configuration);
			//services.AddRoomDesignerServices();          

            //services.AddFluentValidationAutoValidation()
                            //.AddValidators();

            //Add Cors
            services.AddCors(o => o.AddPolicy("Cors", builder =>
            {
                builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            })); 
            services.AddSwaggerServices();

            //services.AddMassTransit(configurator =>
            //{
            //    configurator.SetKebabCaseEndpointNameFormatter();
            //    configurator.UsingRabbitMq((context, cfg) =>
            //    {
            //        var rmqSettings = Configuration.Get<ApplicationSettings>()!.RmqSettings;
            //        cfg.Host(rmqSettings.Host,
            //                    rmqSettings.VHost,
            //                    h =>
            //                    {
            //                        h.Username(rmqSettings.Login);
            //                        h.Password(rmqSettings.Password);
            //                    });
            //        cfg.ConfigureEndpoints(context);
            //    });
            //});
        }

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseSwaggerServices();
			}
			else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
			}

			app.UseCors("Cors");
			app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            //app.UseErrorHandler();

			//Добавляем аутентификацию и ваторизацию в обработку запросов.
			app.UseAuthentication();
			app.UseCustomMiddleware();
            app.UseAuthorization();	


			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});

			//app.MigrateDatabase<ApplicationDbContext>();
		}
	}
}
