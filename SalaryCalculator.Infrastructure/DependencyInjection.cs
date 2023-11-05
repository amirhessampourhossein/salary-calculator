using Dapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SalaryCalculator.Application.Abstractions;
using SalaryCalculator.Application.EmployeeSalaries;
using SalaryCalculator.Domain.EmployeeSalaries;
using SalaryCalculator.Infrastructure.Configurations;
using SalaryCalculator.Infrastructure.Repositories;
using SalaryCalculator.Infrastructure.Services;
using System.Globalization;

namespace SalaryCalculator.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString =
            configuration.GetConnectionString("Default") ??
            throw new ArgumentNullException(nameof(configuration));

        SqlMapper.AddTypeHandler(new IdTypeHandler());
        SqlMapper.AddTypeHandler(new NameTypeHandler());
        SqlMapper.AddTypeHandler(new MoneyTypeHandler());
        SqlMapper.AddTypeHandler(new DateTypeHandler());

        services.AddSingleton<PersianCalendar>();

        services.AddTransient<IDateConverter, PersianDateConverter>();

        services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

        services.AddSingleton<ISqlConnectionFactory>(_ => new SqlConnectionFactory(connectionString));

        services.AddTransient<IStringMapper<EmployeeSalary>, StringMapper>();

        services.AddScoped<IEmployeeSalaryRepository, EmployeeSalaryRepository>();

        return services;
    }
    public static void EnsureDatabaseCreated(this IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        dbContext.Database.EnsureCreated();
    }
}
