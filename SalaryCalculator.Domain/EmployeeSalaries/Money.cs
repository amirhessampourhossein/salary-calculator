namespace SalaryCalculator.Domain.EmployeeSalaries;

public record Money(decimal Amount)
{
    public static Money operator +(Money left, Money right)
        => new(left.Amount + right.Amount);

    public static Money Zero => new(0);
}