using MediatR;
using SalaryCalculator.Application.Abstractions;
using SalaryCalculator.Application.Models;
using SalaryCalculator.Domain.EmployeeSalaries;

namespace SalaryCalculator.Application.EmployeeSalaries.CreateEmployeeSalary;

public class CreateEmployeeSalaryCommandHandler(
    IEmployeeSalaryRepository employeeSalaryRepository,
    IStringMapper<EmployeeSalary> dataMapper)
    : IRequestHandler<CreateEmployeeSalaryCommand, Result>
{
    public async Task<Result> Handle(CreateEmployeeSalaryCommand request, CancellationToken cancellationToken)
    {
        var employeeSalary = dataMapper.Map(request.Data, request.DataType);

        var overtime = OvertimeService.CalculateOvertime(employeeSalary, request.OvertimeCalculator);

        employeeSalary.TotalSalary = employeeSalary.BasicSalary
            + employeeSalary.Allowance
            + employeeSalary.Transportation
            + overtime;

        employeeSalary.Id = Guid.NewGuid();

        var addedId = await employeeSalaryRepository.AddAsync(employeeSalary);

        return Result.Success(addedId.Value, Result.SuccessMessages.Create);
    }
}
