using MediatR;
using SalaryCalculator.Application.Abstractions;
using SalaryCalculator.Application.Models;
using SalaryCalculator.Domain.EmployeeSalaries;

namespace SalaryCalculator.Application.EmployeeSalaries.CreateEmployeeSalary;

public class CreateEmployeeSalaryCommandHandler : IRequestHandler<CreateEmployeeSalaryCommand, Result<Guid?>>
{
    private readonly IEmployeeSalaryRepository _employeeSalaryRepository;
    private readonly IStringMapper<EmployeeSalary> _stringMapper;

    public CreateEmployeeSalaryCommandHandler(IEmployeeSalaryRepository employeeSalaryRepository, IStringMapper<EmployeeSalary> dataMapper)
    {
        _employeeSalaryRepository = employeeSalaryRepository;
        _stringMapper = dataMapper;
    }

    public async Task<Result<Guid?>> Handle(CreateEmployeeSalaryCommand request, CancellationToken cancellationToken)
    {
        var employeeSalary = _stringMapper.Map(request.Data, request.DataType);

        if (employeeSalary is null)
            return Result<Guid?>.BadRequest(Errors.CouldNotMapData);

        var overtime = OvertimeService.CalculateOvertime(employeeSalary, request.OvertimeCalculator);

        if (overtime is null)
            return Result<Guid?>.NotFound(Errors.OvertimeMethodNotFound);

        employeeSalary.TotalSalary = employeeSalary.BasicSalary
            + employeeSalary.Allowance
            + employeeSalary.Transportation
            + overtime;

        employeeSalary.Id = EmployeeSalaryId.New();

        var addedId = await _employeeSalaryRepository.AddAsync(employeeSalary);

        return Result<Guid?>.Created(addedId.Value, Messages.SuccessfulCreate);
    }
}
