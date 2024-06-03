using Reservation.Core.EFContext;
using Hotel_Reservation.Extensions;
using Hotel_Reservation.Mappings;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Serilog;
using FluentValidation.AspNetCore;
using Newtonsoft.Json;
using Hotel_Reservation.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Hotel_Reservation.Extensions.GlobalExceptionHandler;
using Reservation.Domain;

namespace Hotel_Reservation
{
	public class Startup
	{
		private IWebHostEnvironment Environment { get; }
		public Startup(IConfiguration configuration, IWebHostEnvironment env)
		{
			Configuration = configuration;

			Environment = env;
			CreateSerilogLogger(configuration);

		}
		private void CreateSerilogLogger(IConfiguration configuration)
		{
			Log.Logger = new LoggerConfiguration()
				.ReadFrom.Configuration(configuration)
				.WriteTo.Console()
				.WriteTo.File("log-.txt", rollingInterval: RollingInterval.Day)
				.CreateLogger();
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddLogging((builder) =>
			{
				builder.AddSerilog(dispose: true);
			});
			services.AddControllers(options =>
			{
			}).AddFluentValidation()
			.AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo
				{
					Title = "HotelApp",
					Version = "v1"
				});
				c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
				{
					In = ParameterLocation.Header,
					Description = "Please insert JWT with Bearer into field",
					Name = "Authorization",
					Type = SecuritySchemeType.ApiKey
				});
				c.AddSecurityRequirement(new OpenApiSecurityRequirement {
				   {
					 new OpenApiSecurityScheme
					 {
					   Reference = new OpenApiReference
					   {
						 Type = ReferenceType.SecurityScheme,
						 Id = "Bearer"
					   }
					  },
					  new string[] { }
					}
				  });
			});

			services.AddDbContexts(Configuration, Environment);
			services.AddInjections();
			// Identity
			services.AddIdentity<User, UserRole>()
				.AddEntityFrameworkStores<DatabaseContext>();
			services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
			services.AddTransient<UserResolverService>();
			services.AddAutoMapper(typeof(MappingProfile));
			// JWT settings
			var jwtSettings = new JwtSettings();
			Configuration.GetSection("JwtSettings").Bind(jwtSettings);
			services.AddSingleton<JwtSettings>(jwtSettings);
			services.AddAuthentication(x =>
			{
				x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
				x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			})
			.AddJwtBearer(options =>
			{
				options.RequireHttpsMetadata = false;
				options.SaveToken = true;
				options.TokenValidationParameters = new TokenValidationParameters
				{
					ValidateIssuerSigningKey = false,
					IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Key)),
					ValidateIssuer = false,
					ValidateAudience = false,
				};
			});
			services.AddCors(options =>
			{
				options.AddDefaultPolicy(
					builder =>
					{
						builder.WithOrigins("*", "http://localhost:4200")
											.AllowAnyHeader()
											.AllowAnyMethod();
					});
			});


			


		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseMiddleware(typeof(ExceptionMiddleware));
			}
			app.UseHttpsRedirection();
			app.UseDefaultFiles();
			app.UseStaticFiles();
			app.UseRouting();
			app.UseMiddleware(typeof(ExceptionMiddleware));
			app.UseCors(builder =>
			{
				builder
				.AllowAnyOrigin()
				.AllowAnyMethod()
				.AllowAnyHeader();
			});

			app.UseAuthentication();
			app.UseAuthorization();
			app.UseSwagger();
			app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Hotel v1"));

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
				endpoints.MapFallbackToFile("/index.html");
			});

		}
	}

}
