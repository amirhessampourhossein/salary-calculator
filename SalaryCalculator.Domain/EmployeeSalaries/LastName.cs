namespace SalaryCalculator.Domain.EmployeeSalaries;

public record LastName(string Value)
{
    public static LastName Empty => new(string.Empty);
}
