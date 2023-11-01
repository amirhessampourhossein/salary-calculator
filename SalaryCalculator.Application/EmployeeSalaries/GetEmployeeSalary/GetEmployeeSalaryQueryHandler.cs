using MediatR;
using SalaryCalculator.Application.Abstractions;
using SalaryCalculator.Application.Models;
using SalaryCalculator.Domain.EmployeeSalaries;

namespace SalaryCalculator.Application.EmployeeSalaries.GetEmployeeSalary;

public class GetEmployeeSalaryQueryHandler : IRequestHandler<GetEmployeeSalaryQuery, Result>
{
    private readonly IRepository<EmployeeSalary, EmployeeSalaryId> _employeeSalaryRepository;

    public GetEmployeeSalaryQueryHandler(IRepository<EmployeeSalary, EmployeeSalaryId> employeeSalaryRepository)
    {
        _employeeSalaryRepository = employeeSalaryRepository;
    }

    public async Task<Result> Handle(GetEmployeeSalaryQuery request, CancellationToken cancellationToken)
    {
        var entry = await _employeeSalaryRepository.GetAsync(
            new EmployeeSalaryId(request.EmployeeSalaryId),
            cancellationToken);

        if (entry is null)
            return Result.Failure(Errors.NotFound);

        return Result.Success(entry.ToDto());
    }
}
