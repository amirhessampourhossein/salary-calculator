using Microsoft.EntityFrameworkCore;
using SalaryCalculator.Domain.EmployeeSalaries;

namespace SalaryCalculator.Infrastructure;

public class ApplicationDbContext(DbContextOptions options)
    : DbContext(options)
{
    public DbSet<EmployeeSalary> EmployeeSalaries => Set<EmployeeSalary>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}
