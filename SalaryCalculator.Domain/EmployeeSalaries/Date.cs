namespace SalaryCalculator.Domain.EmployeeSalaries;

public record Date(DateTime Value)
{
    public static Date MinValue => new(DateTime.MinValue);
}
