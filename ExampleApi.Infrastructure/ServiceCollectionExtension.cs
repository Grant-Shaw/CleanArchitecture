using ExampleApi.Application.Common.Interfaces.Authentication;
using ExampleApi.Application.Common.Services;
using ExampleApi.Infrastructure.Authentication;
using ExampleApi.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ExampleApi.Application;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfraServices(this IServiceCollection services)
    {
        services.AddSingleton<IJWTTokenGenerator, JWTTokenGenerator>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        return services;
    }
}
