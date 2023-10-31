using MediatR;
using SalaryCalculator.Application.Models;

namespace SalaryCalculator.Application.EmployeeSalaries.GetRangeEmployeeSalaries;

public class GetRangeEmployeeSalaryQueryHandler : IRequestHandler<GetRangeEmployeeSalaryQuery, Result>
{
    private readonly IEmployeeSalaryRepository _employeeSalaryRepository;

    public GetRangeEmployeeSalaryQueryHandler(IEmployeeSalaryRepository employeeSalaryRepository)
    {
        _employeeSalaryRepository = employeeSalaryRepository;
    }

    public async Task<Result> Handle(GetRangeEmployeeSalaryQuery request, CancellationToken cancellationToken)
    {
        var entries = await _employeeSalaryRepository.GetRangeAsync(request.DateRange, cancellationToken);

        if (entries is null || !entries.Any())
            return Result.Failure(Errors.NotFoundRange);

        var mappedEntries = entries
            .Select(employeeSalary => employeeSalary.ToDto())
            .ToList();

        return Result.Success(mappedEntries);
    }
}
