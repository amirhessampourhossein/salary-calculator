using MediatR;
using SalaryCalculator.Application.Abstractions;
using SalaryCalculator.Application.Models;
using SalaryCalculator.Domain.EmployeeSalaries;

namespace SalaryCalculator.Application.EmployeeSalaries.GetRangeEmployeeSalaries;

public class GetRangeEmployeeSalaryQueryHandler : IRequestHandler<GetRangeEmployeeSalaryQuery, Result>
{
    private readonly IEmployeeSalaryRepository _employeeSalaryRepository;
    private readonly IDateConverter _dateConverter;

    public GetRangeEmployeeSalaryQueryHandler(IEmployeeSalaryRepository employeeSalaryRepository, IDateConverter dateConverter)
    {
        _employeeSalaryRepository = employeeSalaryRepository;
        _dateConverter = dateConverter;
    }

    public async Task<Result> Handle(GetRangeEmployeeSalaryQuery request, CancellationToken cancellationToken)
    {
        Date startDate = _dateConverter.ConvertToGregorianDate(request.PersianStartDate);
        Date endDate = _dateConverter.ConvertToGregorianDate(request.PersianEndDate);

        var employeeSalaries = await _employeeSalaryRepository.GetByDateRangeAsync(startDate, endDate);

        var resultValue = employeeSalaries
            .Select(employeeSalary => employeeSalary.ToDto(_dateConverter))
            .ToList();

        return Result.Success(resultValue, Result.SuccessMessages.Read);
    }
}
