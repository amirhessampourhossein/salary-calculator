namespace SalaryCalculator.Domain.EmployeeSalaries;

public record EmployeeSalaryId(Guid Value)
{
    public static EmployeeSalaryId New() => new(Guid.NewGuid());
    public static EmployeeSalaryId Empty => new(Guid.Empty);
}
