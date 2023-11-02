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
        var target = await _employeeSalaryRepository.GetByIdAsync(new(request.EmployeeSalaryId));

        if (target is null)
            return Result.NotFound(Errors.SalaryRecordNotFound);

        var employeeSalary = _stringMapper.Map(request.Data, request.DataType);

        if (employeeSalary is null)
            return Result.BadRequest(Errors.CouldNotMapData);

        var overtime = OvertimeService.CalculateOvertime(employeeSalary, request.OvertimeMethod);

        if (overtime is null)
            return Result.NotFound(Errors.OvertimeMethodNotFound);

        employeeSalary.TotalSalary = employeeSalary.BasicSalary
            + employeeSalary.Allowance
            + employeeSalary.Transportation
            + overtime;

        employeeSalary.Id = target.Id;

        await _employeeSalaryRepository.UpdateAsync(employeeSalary);

        return Result.Ok(Messages.SuccessfulUpdate);
    }
}
