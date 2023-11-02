using MediatR;
using SalaryCalculator.Application.Abstractions;
using SalaryCalculator.Application.Models;
using SalaryCalculator.Domain.EmployeeSalaries;

namespace SalaryCalculator.Application.EmployeeSalaries.GetRangeEmployeeSalaries;

public class GetRangeEmployeeSalaryQueryHandler : IRequestHandler<GetRangeEmployeeSalaryQuery, Result<IReadOnlyList<EmployeeSalaryResponse>>>
{
    private readonly IEmployeeSalaryRepository _employeeSalaryRepository;
    private readonly IDateConverter _dateConverter;

    public GetRangeEmployeeSalaryQueryHandler(IEmployeeSalaryRepository employeeSalaryRepository, IDateConverter dateConverter)
    {
        _employeeSalaryRepository = employeeSalaryRepository;
        _dateConverter = dateConverter;
    }

    public async Task<Result<IReadOnlyList<EmployeeSalaryResponse>>> Handle(GetRangeEmployeeSalaryQuery request, CancellationToken cancellationToken)
    {
        Date startDate = new(_dateConverter.ConvertToGregorianDate(request.PersianStartDate));
        Date endDate = new(_dateConverter.ConvertToGregorianDate(request.PersianEndDate));

        var employeeSalaries = await _employeeSalaryRepository.GetByDateRangeAsync(startDate, endDate);

        if (!employeeSalaries.Any())
            return Result<IReadOnlyList<EmployeeSalaryResponse>>.NotFound(Errors.SalaryRecordNotFoundInRange);

        var resultValue = employeeSalaries
            .Select(employeeSalary => employeeSalary.ToDto())
            .ToList();

        return Result<IReadOnlyList<EmployeeSalaryResponse>>.Ok(resultValue);
    }
}
