using MediatR;
using SalaryCalculator.Application.Abstractions;
using SalaryCalculator.Application.Models;
using SalaryCalculator.Domain.EmployeeSalaries;

namespace SalaryCalculator.Application.EmployeeSalaries.GetRangeEmployeeSalaries;

public class GetRangeEmployeeSalaryQueryHandler(
    IEmployeeSalaryRepository employeeSalaryRepository,
    IDateConverter dateConverter)
    : IRequestHandler<GetRangeEmployeeSalaryQuery, Result>
{
    public async Task<Result> Handle(GetRangeEmployeeSalaryQuery request, CancellationToken cancellationToken)
    {
        Date startDate = dateConverter.ConvertToGregorianDate(request.PersianStartDate);
        Date endDate = dateConverter.ConvertToGregorianDate(request.PersianEndDate);

        var employeeSalaries = await employeeSalaryRepository.GetByDateRangeAsync(startDate, endDate);

        var resultValue = employeeSalaries
            .Select(employeeSalary => employeeSalary.ToDto(dateConverter))
            .ToList();

        return Result.Success(resultValue, Result.SuccessMessages.Read);
    }
}
