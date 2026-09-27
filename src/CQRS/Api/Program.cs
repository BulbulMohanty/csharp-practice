using Api.DB;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//Register DbContext with PostgreSQL
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(connectionString));
// Add services to the container.

//Add mediater
builder.Services.AddMediatR(configuration => 
configuration.RegisterServicesFromAssembly(typeof(Program).Assembly)
);

// Retrieve the license key from configuration
var licenseKey = builder.Configuration["AutoMapper:LicenseKey"];
//Register all profile classes found in the current assembly
builder.Services.AddAutoMapper(cfg =>
{
    cfg.LicenseKey = licenseKey;
},
AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddControllers();

// Add Swagger/OpenAPI services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
