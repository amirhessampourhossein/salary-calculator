using System.Globalization;

namespace SalaryCalculator.Domain.EmployeeSalaries;

public record Date(DateOnly Value)
{
    public string ToInvariantDate() 
        => Value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);

    public static implicit operator Date(DateOnly Value) => new(Value);
}
