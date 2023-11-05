namespace SalaryCalculator.Domain.EmployeeSalaries;

public record Money(decimal Amount)
{
    public static Money operator +(Money left, Money right)
        => left.Amount + right.Amount;

    public static implicit operator Money(decimal value) => new(value);
}