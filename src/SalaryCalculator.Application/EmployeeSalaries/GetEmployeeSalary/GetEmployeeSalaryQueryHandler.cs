using MediatR;
using SalaryCalculator.Application.Abstractions;
using SalaryCalculator.Application.Models;

namespace SalaryCalculator.Application.EmployeeSalaries.GetEmployeeSalary;

public class GetEmployeeSalaryQueryHandler(
    IEmployeeSalaryRepository employeeSalaryRepository,
    IDateConverter dateConverter)
    : IRequestHandler<GetEmployeeSalaryQuery, Result>
{
    public async Task<Result> Handle(GetEmployeeSalaryQuery request, CancellationToken cancellationToken)
    {
        var employeeSalary = await employeeSalaryRepository.GetByIdAsync(request.EmployeeSalaryId);

        return Result.Success(employeeSalary.ToDto(dateConverter), Result.SuccessMessages.Read);
    }
}
