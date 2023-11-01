using MediatR;
using OvertimePolicies;
using SalaryCalculator.Application.Abstractions;
using SalaryCalculator.Application.Models;
using SalaryCalculator.Domain.EmployeeSalaries;

namespace SalaryCalculator.Application.EmployeeSalaries.AddEmployeeSalary;

public class AddEmployeeSalaryCommandHandler : IRequestHandler<AddEmployeeSalaryCommand, Result>
{
    private readonly IRepository<EmployeeSalary, EmployeeSalaryId> _employeeSalaryRepository;
    private readonly IStringMapper<EmployeeSalary> _dataMapper;

    public AddEmployeeSalaryCommandHandler(IRepository<EmployeeSalary, EmployeeSalaryId> employeeSalaryRepository, IStringMapper<EmployeeSalary> dataMapper)
    {
        _employeeSalaryRepository = employeeSalaryRepository;
        _dataMapper = dataMapper;
    }

    public async Task<Result> Handle(AddEmployeeSalaryCommand request, CancellationToken cancellationToken)
    {
        var mappedData = _dataMapper.Map(request.Data);

        if (mappedData is null)
            return Result.Failure(Errors.FailedToMapData);

        Money? overtimeMethodResult = request.OvertimeCalculator.ToLower() switch
        {
            "calculatea" => new(OvertimeMethods.CalculateA(mappedData.BasicSalary.Amount, mappedData.Allowance.Amount)),
            "calculateb" => new(OvertimeMethods.CalculateB(mappedData.BasicSalary.Amount, mappedData.Allowance.Amount)),
            "calculatec" => new(OvertimeMethods.CalculateC(mappedData.BasicSalary.Amount, mappedData.Allowance.Amount)),
            _ => null
        };

        if (overtimeMethodResult is null)
            return Result.Failure(Errors.OvertimeMethodNotFound);

        mappedData.TotalSalary = mappedData.BasicSalary + mappedData.Allowance + mappedData.Transportation + overtimeMethodResult;

        var addedId = await _employeeSalaryRepository.AddAsync(
            mappedData,
            cancellationToken);

        return Result.Success(addedId.Value);
    }
}
