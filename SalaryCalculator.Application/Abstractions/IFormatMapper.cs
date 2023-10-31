namespace SalaryCalculator.Application.Abstractions;

public interface IFormatMapper<T>
    where T : class
{
    bool CanMap(string data);

    T? Map(string data);
}
