using AutoMapper;
using Hangfire;
using Hangfire.MySql.Core;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Data;
using Internitlaw.Api.AutoMapper;
using Internitlaw.Api.Extensions;
using Internitlaw.Domain.Security;
using Internitlaw.Repository.EFContext;

namespace Internitlaw.Api
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllers().AddNewtonsoftJson();

			var connectionString = Configuration.GetConnectionString("InternitlawContext");
			services.AddDbContext<InternitlawContext>(options =>
			{
				options.UseMySQL(connectionString);
			});

			services.Configure<TokenOptions>(Configuration.GetSection("TokenOptions"));
			var tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();

			var signingConfigurations = new SigningConfigurations(tokenOptions.Secret);
			services.AddSingleton(signingConfigurations);

			services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
				.AddJwtBearer(jwtBearerOptions =>
				{
					jwtBearerOptions.TokenValidationParameters = new TokenValidationParameters()
					{
						ValidateAudience = true,
						ValidateLifetime = true,
						ValidateIssuerSigningKey = true,
						ValidIssuer = tokenOptions.Issuer,
						ValidAudience = tokenOptions.Audience,
						IssuerSigningKey = signingConfigurations.SecurityKey,
						//ClockSkew = TimeSpan.Zero
					};
				});

			services.AddHangfire(x => x.UseStorage(new MySqlStorage(connectionString, 
				new MySqlStorageOptions() {
					TransactionIsolationLevel = IsolationLevel.ReadCommitted,
					QueuePollInterval = TimeSpan.FromSeconds(15),
					JobExpirationCheckInterval = TimeSpan.FromHours(1),
					CountersAggregateInterval = TimeSpan.FromMinutes(5),
					PrepareSchemaIfNecessary = true,
					DashboardJobListLimit = 50000,
					TransactionTimeout = TimeSpan.FromMinutes(1),
					TablePrefix = "Hangfire"
				})));

			services.AddAutoMapper(typeof(ModelProfiles));
			services.AddCustomSwagger();
			services.AddDIServices();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			//Because requests are forwarded by reverse proxy, use the Forwarded Headers Middleware 
			app.UseForwardedHeaders(new ForwardedHeadersOptions
			{
				ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
			});

			//app.UseHttpsRedirection();

			app.UseRouting();

			app.UseCors(builder => builder
				.AllowAnyOrigin()
				.AllowAnyMethod()
				.AllowAnyHeader()
				//.AllowCredentials()
			);		

			app.UseAuthentication();
			app.UseAuthorization();
			app.UseHangfireServer(new BackgroundJobServerOptions
			{
				WorkerCount = 1
			});
			app.UseHangfireDashboard("/hangfire", new DashboardOptions
			{
			});

			BackgroundJob.Enqueue(() => Console.WriteLine("Hello world from Hangfire!"));

			app.UseCustomSwagger();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
	
}
