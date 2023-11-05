using MediatR;
using SalaryCalculator.Application.Abstractions;
using SalaryCalculator.Application.Models;
using SalaryCalculator.Domain.EmployeeSalaries;

namespace SalaryCalculator.Application.EmployeeSalaries.CreateEmployeeSalary;

public class CreateEmployeeSalaryCommandHandler : IRequestHandler<CreateEmployeeSalaryCommand, Result>
{
    private readonly IEmployeeSalaryRepository _employeeSalaryRepository;
    private readonly IStringMapper<EmployeeSalary> _stringMapper;

    public CreateEmployeeSalaryCommandHandler(IEmployeeSalaryRepository employeeSalaryRepository, IStringMapper<EmployeeSalary> dataMapper)
    {
        _employeeSalaryRepository = employeeSalaryRepository;
        _stringMapper = dataMapper;
    }

    public async Task<Result> Handle(CreateEmployeeSalaryCommand request, CancellationToken cancellationToken)
    {
        var employeeSalary = _stringMapper.Map(request.Data, request.DataType);

        var overtime = OvertimeService.CalculateOvertime(employeeSalary, request.OvertimeCalculator);

        employeeSalary.TotalSalary = employeeSalary.BasicSalary
            + employeeSalary.Allowance
            + employeeSalary.Transportation
            + overtime;

        employeeSalary.Id = Id.New();

        var addedId = await _employeeSalaryRepository.AddAsync(employeeSalary);

        return Result.Success(addedId.Value, Result.SuccessMessages.Create);
    }
}
