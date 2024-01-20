using MediatR;
using SalaryCalculator.Application.Abstractions;
using SalaryCalculator.Application.Models;
using SalaryCalculator.Domain.EmployeeSalaries;

namespace SalaryCalculator.Application.EmployeeSalaries.UpdateEmployeeSalary;

public class UpdateEmployeeSalaryCommandHandler : IRequestHandler<UpdateEmployeeSalaryCommand, Result>
{
    private readonly IEmployeeSalaryRepository _employeeSalaryRepository;
    private readonly IStringMapper<EmployeeSalary> _stringMapper;

    public UpdateEmployeeSalaryCommandHandler(IEmployeeSalaryRepository employeeSalaryRepository, IStringMapper<EmployeeSalary> dataMapper)
    {
        _employeeSalaryRepository = employeeSalaryRepository;
        _stringMapper = dataMapper;
    }

    public async Task<Result> Handle(UpdateEmployeeSalaryCommand request, CancellationToken cancellationToken)
    {
        var newEmployeeSalary = _stringMapper.Map(request.Data, request.DataType);

        var overtime = OvertimeService.CalculateOvertime(newEmployeeSalary, request.OvertimeMethod);

        newEmployeeSalary.TotalSalary = newEmployeeSalary.BasicSalary
            + newEmployeeSalary.Allowance
            + newEmployeeSalary.Transportation
            + overtime;

        await _employeeSalaryRepository.UpdateAsync(request.EmployeeSalaryId, newEmployeeSalary);

        return Result.Success(Result.SuccessMessages.Update);
    }
}
