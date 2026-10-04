using Api.DB;
using Asp.Versioning;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

namespace Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Register DbContext with PostgreSQL
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(connectionString));

            // Add MediatR
            builder.Services.AddMediatR(configuration => 
                configuration.RegisterServicesFromAssembly(typeof(Program).Assembly)
            );

            // Retrieve the license key from configuration
            var licenseKey = builder.Configuration["AutoMapper:LicenseKey"];
            // Register all profile classes found in the current assembly
            builder.Services.AddAutoMapper(cfg =>
            {
                cfg.LicenseKey = licenseKey;
            },
            AppDomain.CurrentDomain.GetAssemblies());

            builder.Services.AddControllers();

            // Add API Versioning with MVC, API Explorer, and OpenAPI integration
            builder.Services.AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.ReportApiVersions = true;
                options.ApiVersionReader = new UrlSegmentApiVersionReader();
            })
            .AddMvc()
            .AddApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            })
            .AddOpenApi();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi().WithDocumentPerVersion();
                app.MapScalarApiReference(options =>
                {
                    options.WithTitle("CQRS API");
                });
            }

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}

