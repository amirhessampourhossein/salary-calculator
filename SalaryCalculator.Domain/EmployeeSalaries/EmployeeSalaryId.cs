namespace SalaryCalculator.Domain.EmployeeSalaries;

public record EmployeeSalaryId(Guid Value)
{
    public static EmployeeSalaryId New() => new(Guid.NewGuid());
}
