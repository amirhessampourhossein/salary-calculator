using SalaryCalculator.Application.Abstractions;
using SalaryCalculator.Application.EmployeeSalaries;
using SalaryCalculator.Domain.EmployeeSalaries;

namespace SalaryCalculator.Infrastructure.Services;

public class StringMapper : IStringMapper<EmployeeSalary>
{
    private readonly List<IFormatMapper<EmployeeSalaryDto>> _formatMappers;

    public StringMapper()
    {
        _formatMappers = new List<IFormatMapper<EmployeeSalaryDto>>()
        {
            new JsonFormatMapper<EmployeeSalaryDto>(),
            new XmlFormatMapper<EmployeeSalaryDto>(),
            new CsvFormatMapper<EmployeeSalaryDto>(),
            new CustomFormatMapper<EmployeeSalaryDto>()
        };
    }

    public EmployeeSalary? Map(string data)
    {
        foreach (var formatMapper in _formatMappers)
        {
            if (formatMapper.CanMap(data))
            {
                var mappedDto = formatMapper.Map(data);

                if (mappedDto is null)
                    return default;

                return mappedDto.ToEntity();
            }
        }

        return default;
    }
}
