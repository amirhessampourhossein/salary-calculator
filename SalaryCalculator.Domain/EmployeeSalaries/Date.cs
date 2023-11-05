using System.Globalization;

namespace SalaryCalculator.Domain.EmployeeSalaries;

public record Date(DateOnly Value)
{
    public static Date MinValue => new(DateOnly.MinValue);

    public string ToInvariantDate() 
        => Value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
}
