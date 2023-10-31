using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace SalaryCalculator.Application;

public static class DependencyInjection
{
    private static readonly Assembly CurrentAssembly = typeof(DependencyInjection).Assembly;

    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(configuration => configuration.RegisterServicesFromAssembly(CurrentAssembly));

        return services;
    }
}
