using SalaryCalculator.Application.Abstractions;
using SalaryCalculator.Application.EmployeeSalaries;
using SalaryCalculator.Domain.EmployeeSalaries;
using SalaryCalculator.Infrastructure.Services.FormatMappers;

namespace SalaryCalculator.Infrastructure.Services;

public class StringMapper : IStringMapper<EmployeeSalary>
{
    private readonly IDateConverter _dateConverter;

    public StringMapper(IDateConverter dateConverter)
    {
        _dateConverter = dateConverter;
    }

    public EmployeeSalary? Map(string data, string dataType)
    {
        var formatMapper = FormatMapper.CreateMapperFromType(dataType);

        if (formatMapper is null)
            return null;

        var employeeSalaryRequest = formatMapper.Map<EmployeeSalaryRequest>(data);

        if (employeeSalaryRequest is null)
            return null;

        return new(EmployeeSalaryId.Empty)
        {
            FirstName = new(employeeSalaryRequest.FirstName),
            LastName = new(employeeSalaryRequest.LastName),
            BasicSalary = new(employeeSalaryRequest.BasicSalary),
            Allowance = new(employeeSalaryRequest.Allowance),
            Transportation = new(employeeSalaryRequest.Transportation),
            Date = new(_dateConverter.ConvertToGregorianDate(employeeSalaryRequest.Date))
        };
    }
}
