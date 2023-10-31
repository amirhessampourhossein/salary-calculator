using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SalaryCalculator.Application.Abstractions;
using SalaryCalculator.Application.EmployeeSalaries;
using SalaryCalculator.Domain.EmployeeSalaries;
using SalaryCalculator.Infrastructure.Repositories;
using SalaryCalculator.Infrastructure.Services;

namespace SalaryCalculator.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IEmployeeSalaryRepository, EmployeeSalaryRepository>();

        services.AddTransient<IStringMapper<EmployeeSalary>, StringMapper>();

        var connectionString =
             configuration.GetConnectionString("Default") ??
             throw new ArgumentNullException(nameof(configuration));

        services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

        services.AddSingleton(_ => new SqlConnectionFactory(connectionString));

        return services;
    }
}
