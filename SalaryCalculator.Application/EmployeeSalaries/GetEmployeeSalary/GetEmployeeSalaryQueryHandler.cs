using MediatR;
using SalaryCalculator.Application.Models;
using SalaryCalculator.Domain.EmployeeSalaries;

namespace SalaryCalculator.Application.EmployeeSalaries.GetEmployeeSalary;

public class GetEmployeeSalaryQueryHandler : IRequestHandler<GetEmployeeSalaryQuery, Result>
{
    private readonly IEmployeeSalaryRepository _employeeSalaryRepository;

    public GetEmployeeSalaryQueryHandler(IEmployeeSalaryRepository employeeSalaryRepository)
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
