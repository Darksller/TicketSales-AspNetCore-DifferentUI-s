using Microsoft.IdentityModel.Tokens;
using System.Text;
using TicketSalesSystem.BLL.Configurations;
using Swashbuckle.AspNetCore.Filters;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Builder;

namespace TicketSalesSystem.ReactUI
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.

			builder.Services.AddControllersWithViews();
			builder.Services.AddHttpContextAccessor();
			builder.Services.AddBusinessLogicServices(builder.Configuration);
			builder.Services.AddSwaggerGen(options =>
			{
				options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
				{
					In = ParameterLocation.Header,
					Name = "Authorization",
					Type = SecuritySchemeType.ApiKey
				});

				options.OperationFilter<SecurityRequirementsOperationFilter>();
			});
			builder.Services.AddAuthentication().AddJwtBearer(options =>
			{
				options.TokenValidationParameters = new TokenValidationParameters
				{
					ValidateIssuerSigningKey = true,
					ValidateAudience = false,
					ValidateIssuer = false,
					IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
							   builder.Configuration.GetSection("Secret").Value!))
				};
			});

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (!app.Environment.IsDevelopment())
			{

			}

			app.UseDeveloperExceptionPage();
			app.UseSwagger();
			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("./v1/swagger.json", "My API V1");
			});
			app.UseRouting();


			app.MapControllerRoute(
				name: "default",
				pattern: "{controller}/{action=Index}/{id?}");

			app.MapFallbackToFile("index.html");
			app.UseAuthorization();
			app.Run();
		}
	}
}