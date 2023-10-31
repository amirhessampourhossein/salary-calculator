using SalaryCalculator.Application.Abstractions;
using SalaryCalculator.Domain.EmployeeSalaries;

namespace SalaryCalculator.Infrastructure.Services;

public class StringMapper : IStringMapper<EmployeeSalary>
{
    private readonly List<IFormatMapper<EmployeeSalary>> _formatMappers;

    public StringMapper()
    {
        _formatMappers = new List<IFormatMapper<EmployeeSalary>>()
        {
            new JsonFormatMapper<EmployeeSalary>(),
            new XmlFormatMapper<EmployeeSalary>(),
            new CsvFormatMapper<EmployeeSalary>(),
            new CustomFormatMapper<EmployeeSalary>()
        };
    }

    public EmployeeSalary? Map(string data)
    {
        foreach (var formatMapper in _formatMappers)
        {
            if (formatMapper.CanMap(data))
                return formatMapper.Map(data);
        }

        return default;
    }
}
