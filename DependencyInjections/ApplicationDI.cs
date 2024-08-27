using EventsBookingBackend.Application.Common.Middlewares;
using EventsBookingBackend.Application.Services.Auth;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Newtonsoft.Json.Serialization;

namespace EventsBookingBackend.DependencyInjections;

public static class ApplicationDi
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddTransient<IAuthService, AuthService>();
    }

    public static void UseMiddlewares(this IApplicationBuilder services)
    {
        services.UseMiddleware<ExceptionMiddleware>();
    }

    public static void AddCommonExtensions(this IServiceCollection services)
    {
        services.AddControllers(options =>
            {
                options.Conventions.Add(new RouteTokenTransformerConvention(new SnakeCaseRoutingConvention()));
            })
            .AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new SnakeCaseNamingStrategy()
                };
            });
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
    }
}