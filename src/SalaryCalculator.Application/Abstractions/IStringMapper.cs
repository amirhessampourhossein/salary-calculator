namespace SalaryCalculator.Application.Abstractions;

public interface IStringMapper<TDestination>
    where TDestination : class
{
    TDestination Map(string data, string dataType);
}
