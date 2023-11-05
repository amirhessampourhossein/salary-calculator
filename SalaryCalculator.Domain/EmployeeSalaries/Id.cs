namespace SalaryCalculator.Domain.EmployeeSalaries;

public record Id(Guid Value)
{
    public static Id New() => new(Guid.NewGuid());
    public static Id Empty => new(Guid.Empty);
}
