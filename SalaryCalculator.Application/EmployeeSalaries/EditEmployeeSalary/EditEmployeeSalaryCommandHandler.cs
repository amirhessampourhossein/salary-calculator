using MediatR;
using SalaryCalculator.Application.Abstractions;
using SalaryCalculator.Application.Models;
using SalaryCalculator.Domain.EmployeeSalaries;

namespace SalaryCalculator.Application.EmployeeSalaries.EditEmployeeSalary;

public class EditEmployeeSalaryCommandHandler : IRequestHandler<EditEmployeeSalaryCommand, Result>
{
    private readonly IEmployeeSalaryRepository _employeeSalaryRepository;
    private readonly IStringMapper<EmployeeSalary> _dataMapper;

    public EditEmployeeSalaryCommandHandler(IEmployeeSalaryRepository employeeSalaryRepository, IStringMapper<EmployeeSalary> dataMapper)
    {
        _employeeSalaryRepository = employeeSalaryRepository;
        _dataMapper = dataMapper;
    }

    public async Task<Result> Handle(EditEmployeeSalaryCommand request, CancellationToken cancellationToken)
    {
        var mappedData = _dataMapper.Map(request.Data);

        if (mappedData is null)
            return Result.Failure(Errors.FailedToMapData);

        var updatedId = await _employeeSalaryRepository.UpdateAsync(
            new EmployeeSalaryId(request.EmployeeSalaryId),
            mappedData,
            cancellationToken);

        if (updatedId is null)
            return Result.Failure(Errors.NotFound);

        return Result.Success(updatedId.Value);
    }
}
