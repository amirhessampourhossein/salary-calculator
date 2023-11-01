using MediatR;
using SalaryCalculator.Application.Abstractions;
using SalaryCalculator.Application.Models;
using SalaryCalculator.Domain.EmployeeSalaries;

namespace SalaryCalculator.Application.EmployeeSalaries.GetRangeEmployeeSalaries;

public class GetRangeEmployeeSalaryQueryHandler : IRequestHandler<GetRangeEmployeeSalaryQuery, Result>
{
    private readonly IRepository<EmployeeSalary, EmployeeSalaryId> _employeeSalaryRepository;

    public GetRangeEmployeeSalaryQueryHandler(IRepository<EmployeeSalary, EmployeeSalaryId> employeeSalaryRepository)
    {
        _employeeSalaryRepository = employeeSalaryRepository;
    }

    public async Task<Result> Handle(GetRangeEmployeeSalaryQuery request, CancellationToken cancellationToken)
    {
        var entries = await _employeeSalaryRepository.GetRangeAsync(request.DateRange, cancellationToken);

        if (entries is null || !entries.Any())
            return Result.Failure(Errors.NotFoundInRange);

        var mappedEntries = entries
            .Select(employeeSalary => employeeSalary.ToDto())
            .ToList();

        return Result.Success(mappedEntries);
    }
}
