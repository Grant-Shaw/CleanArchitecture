using ExampleApi.Application.Services.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace ExampleApi.Application;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddAuthService(this IServiceCollection services)
    {
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        return services;
    }
}
