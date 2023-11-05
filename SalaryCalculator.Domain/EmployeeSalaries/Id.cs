namespace SalaryCalculator.Domain.EmployeeSalaries;

public record Id(Guid Value)
{
    public static implicit operator Id(Guid value) => new(value);
}
