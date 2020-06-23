using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;

namespace Internitlaw.Api.Extensions
{
	public static class MiddlewareExtensions
	{
		public static IServiceCollection AddCustomSwagger(this IServiceCollection services)
		{
			services.AddSwaggerGen(cfg =>
			{
				cfg.SwaggerDoc("v1", new OpenApiInfo
				{
					Title = "Internitlaw API",
					Version = "v3",
					Description = "This API Powers the backend for the Covid19 Screening Survey",
					Contact = new OpenApiContact
					{
						Name = "I. Zvovuranda",
						// Url = new Uri("https://google.com/")
					},
					License = new OpenApiLicense
					{
						// Name = "MIT",
					},
				});

				cfg.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
				{
					In = ParameterLocation.Header,
					Description = "JSON Web Token to access resources. Example: Bearer {token}",
					Name = "Authorization",
					Type = SecuritySchemeType.ApiKey
				});

				cfg.AddSecurityRequirement(new OpenApiSecurityRequirement
				{
					{
						new OpenApiSecurityScheme
						{
							Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
						},
						new [] { string.Empty }
					}
				});

				//var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
				//var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
				//cfg.IncludeXmlComments(xmlPath);
			});

			return services;
		}

		public static IApplicationBuilder UseCustomSwagger(this IApplicationBuilder app)
		{
			app.UseSwagger().UseSwaggerUI(options =>
			{

				//c.SwaggerEndpoint("/survey/swagger/v1/swagger.json", "Survey API");

				options.DocumentTitle = "Internitlaw API";
#if DEBUG
				// For Debug in Kestrel
				options.SwaggerEndpoint("/swagger/v1/swagger.json", "Survey API");
#else
													 // To deploy on live.
					 		 options.SwaggerEndpoint("/internitlaw-api/swagger/v1/swagger.json", "Survey API");
#endif
				options.RoutePrefix = string.Empty;
			});

			return app;
		}
	}
}
