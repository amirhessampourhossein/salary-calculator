using MediatR;
using SalaryCalculator.Application.Abstractions;
using SalaryCalculator.Application.Models;

namespace SalaryCalculator.Application.EmployeeSalaries.GetEmployeeSalary;

public class GetEmployeeSalaryQueryHandler : IRequestHandler<GetEmployeeSalaryQuery, Result>
{
    private readonly IEmployeeSalaryRepository _employeeSalaryRepository;
    private readonly IDateConverter _dateConverter;

    public GetEmployeeSalaryQueryHandler(IEmployeeSalaryRepository employeeSalaryRepository, IDateConverter dateConverter)
    {
        _employeeSalaryRepository = employeeSalaryRepository;
        _dateConverter = dateConverter;
    }

    public async Task<Result> Handle(GetEmployeeSalaryQuery request, CancellationToken cancellationToken)
    {
        var employeeSalary = await _employeeSalaryRepository.GetByIdAsync(request.EmployeeSalaryId);

        return Result.Success(employeeSalary.ToDto(_dateConverter), Result.SuccessMessages.Read);
    }
}
