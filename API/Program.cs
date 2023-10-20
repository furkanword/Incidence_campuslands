using System.Reflection;
using API.Extensions;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using AspNetCoreRateLimit;
var builder = WebApplication.CreateBuilder(args);
builder.Services.ConfigureCors();
builder.Services.ConfigureRatelimiting();
builder.Services.ConfigureApiVersioning();
builder.Services.AddApplicationServices();
builder.Services.AddAutoMapper(Assembly.GetEntryAssembly());

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<IncidenceContext>(options =>
{
    string ? connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseIpRateLimiting();

app.UseAuthorization();

app.MapControllers();

app.Run();
