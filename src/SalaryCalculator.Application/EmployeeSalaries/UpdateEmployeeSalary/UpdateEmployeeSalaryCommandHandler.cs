using MediatR;
using SalaryCalculator.Application.Abstractions;
using SalaryCalculator.Application.Models;
using SalaryCalculator.Domain.EmployeeSalaries;

namespace SalaryCalculator.Application.EmployeeSalaries.UpdateEmployeeSalary;

public class UpdateEmployeeSalaryCommandHandler(
    IEmployeeSalaryRepository employeeSalaryRepository,
    IStringMapper<EmployeeSalary> dataMapper)
    : IRequestHandler<UpdateEmployeeSalaryCommand, Result>
{
    public async Task<Result> Handle(UpdateEmployeeSalaryCommand request, CancellationToken cancellationToken)
    {
        var newEmployeeSalary = dataMapper.Map(request.Data, request.DataType);

        var overtime = OvertimeService.CalculateOvertime(newEmployeeSalary, request.OvertimeMethod);

        newEmployeeSalary.TotalSalary = newEmployeeSalary.BasicSalary
            + newEmployeeSalary.Allowance
            + newEmployeeSalary.Transportation
            + overtime;

        await employeeSalaryRepository.UpdateAsync(request.EmployeeSalaryId, newEmployeeSalary);

        return Result.Success(Result.SuccessMessages.Update);
    }
}
