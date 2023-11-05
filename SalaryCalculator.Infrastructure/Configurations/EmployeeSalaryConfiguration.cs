using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SalaryCalculator.Domain.EmployeeSalaries;

namespace SalaryCalculator.Infrastructure.Configurations;

public class EmployeeSalaryConfiguration : IEntityTypeConfiguration<EmployeeSalary>
{
    public void Configure(EntityTypeBuilder<EmployeeSalary> builder)
    {
        builder.ToTable("EmployeeSalaries");

        builder.HasKey(employeeSalary => employeeSalary.Id);

        builder.Property(employeeSalary => employeeSalary.Id)
            .HasConversion(id => id.Value, value => new(value));

        builder.Property(employeeSalary => employeeSalary.FirstName)
            .HasConversion(firstName => firstName.Value, value => new(value));

        builder.Property(employeeSalary => employeeSalary.LastName)
            .HasConversion(lastName => lastName.Value, value => new(value));

        builder.Property(employeeSalary => employeeSalary.BasicSalary)
            .HasConversion(salary => salary.Amount, amount => new(amount));

        builder.Property(employeeSalary => employeeSalary.Allowance)
            .HasConversion(allowance => allowance.Amount, amount => new(amount));

        builder.Property(employeeSalary => employeeSalary.Transportation)
            .HasConversion(transportation => transportation.Amount, amount => new(amount));

        builder.Property(employeeSalary => employeeSalary.TotalSalary)
            .HasConversion(totalSalary => totalSalary.Amount, amount => new(amount));

        builder.Property(employeeSalary => employeeSalary.Date)
            .HasConversion(date => date.Value.ToDateTime(TimeOnly.MinValue), value => new(DateOnly.FromDateTime(value)));
    }
}
