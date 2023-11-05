using SalaryCalculator.Application.Abstractions;
using SalaryCalculator.Application.EmployeeSalaries;
using SalaryCalculator.Application.Exceptions;
using SalaryCalculator.Domain.EmployeeSalaries;
using SalaryCalculator.Infrastructure.Services.FormatMappers;
using Throw;

namespace SalaryCalculator.Infrastructure.Services;

public class StringMapper : IStringMapper<EmployeeSalary>
{
    private readonly IDateConverter _dateConverter;

    public StringMapper(IDateConverter dateConverter)
    {
        _dateConverter = dateConverter;
    }

    public EmployeeSalary Map(string data, string dataType)
    {
        var formatMapper = FormatMapper.CreateMapperFromType(dataType);

        formatMapper.ThrowIfNull(() => throw new FailedToCreateFormatMapperException());

        var employeeSalaryDto = formatMapper.Map<EmployeeSalaryDto>(data);

        employeeSalaryDto.ThrowIfNull(() => throw new FailedToMapStringException());

        return employeeSalaryDto.ToEntity(_dateConverter);
    }
}
