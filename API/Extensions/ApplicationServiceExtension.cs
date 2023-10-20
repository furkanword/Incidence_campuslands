using AspNetCoreRateLimit;
using Core.Interfaces;
using Infrastructure.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Options;

namespace API.Extensions;
//Configurar las politicas cors
public static class ApplicationServiceExtension{
    public static void ConfigureCors(this IServiceCollection service)=>service.AddCors(
        option=>{
            option.AddPolicy(
                name:"CorsPolicy",
                builder=>builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
            );
        }
    );

    public static void ConfigureRatelimiting(this IServiceCollection services){
        services.AddMemoryCache();
        services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
        services.AddInMemoryRateLimiting();
        services.Configure<IpRateLimitOptions>(Options =>{
            Options.EnableEndpointRateLimiting = true;
            Options.StackBlockedRequests = false;
            Options.HttpStatusCode = 429;
            Options.RealIpHeader = "X-Real-Ip";
            Options.GeneralRules = new() {
                new(){
                    Endpoint = "*",
                    Period = "10s",
                    Limit = 2
                }
            };
        });
    }

    public static void ConfigureApiVersioning(this IServiceCollection services){
        services.AddApiVersioning(Options=>{
            Options.DefaultApiVersion = new ApiVersion(1,0);
            Options.AssumeDefaultVersionWhenUnspecified = true;
            /* Options.ApiVersionReader = new QueryStringApiVersionReader("v");
            Options.ApiVersionReader = new HeaderApiVersionReader("X-Version"); */
            Options.ApiVersionReader = ApiVersionReader.Combine(
                new QueryStringApiVersionReader("v"),
                new HeaderApiVersionReader("X-Version")
            );
        });
    }

    public static void AddApplicationServices(this IServiceCollection services){
        services.AddScoped<IUnitOfWork,UnitOfWork>();
    }
    
}