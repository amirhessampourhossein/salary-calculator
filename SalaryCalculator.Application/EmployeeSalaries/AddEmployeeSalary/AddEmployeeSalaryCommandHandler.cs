using MediatR;
using OvertimePolicies;
using SalaryCalculator.Application.Abstractions;
using SalaryCalculator.Application.Models;
using SalaryCalculator.Domain.EmployeeSalaries;

namespace SalaryCalculator.Application.EmployeeSalaries.AddEmployeeSalary;

public class AddEmployeeSalaryCommandHandler : IRequestHandler<AddEmployeeSalaryCommand, Result>
{
    private readonly IEmployeeSalaryRepository _employeeSalaryRepository;
    private readonly IStringMapper<EmployeeSalary> _dataMapper;

    public AddEmployeeSalaryCommandHandler(IEmployeeSalaryRepository employeeSalaryRepository, IStringMapper<EmployeeSalary> dataMapper)
    {
        _employeeSalaryRepository = employeeSalaryRepository;
        _dataMapper = dataMapper;
    }

    public async Task<Result> Handle(AddEmployeeSalaryCommand request, CancellationToken cancellationToken)
    {
        var mappedData = _dataMapper.Map(request.Data);

        if (mappedData is null)
            return Result.Failure(Errors.FailedToMapData);

        Money? overtimeMethodResult;
        overtimeMethodResult = request.OvertimeCalculator switch
        {
            nameof(OvertimeMethods.CalculateA) => new(OvertimeMethods.CalculateA(mappedData.BasicSalary.Amount, mappedData.Allowance.Amount)),
            nameof(OvertimeMethods.CalculateB) => new(OvertimeMethods.CalculateB(mappedData.BasicSalary.Amount, mappedData.Allowance.Amount)),
            nameof(OvertimeMethods.CalculateC) => new(OvertimeMethods.CalculateC(mappedData.BasicSalary.Amount, mappedData.Allowance.Amount)),
            _ => null
        };

        if (overtimeMethodResult is null)
            return Result.Failure(Errors.NotFoundMethod);

        mappedData.TotalSalary = mappedData.BasicSalary + mappedData.Allowance + mappedData.Transportation + overtimeMethodResult;

        var addedId = await _employeeSalaryRepository.AddAsync(
            mappedData,
            cancellationToken);

        return Result.Success(addedId.Value);
    }
}
