using MediatR;
using SalaryCalculator.Application.Models;

namespace SalaryCalculator.Application.EmployeeSalaries.GetEmployeeSalary;

public class GetEmployeeSalaryQueryHandler : IRequestHandler<GetEmployeeSalaryQuery, Result<EmployeeSalaryResponse>>
{
    private readonly IEmployeeSalaryRepository _employeeSalaryRepository;

    public GetEmployeeSalaryQueryHandler(IEmployeeSalaryRepository employeeSalaryRepository)
    {
        _employeeSalaryRepository = employeeSalaryRepository;
    }

    public async Task<Result<EmployeeSalaryResponse>> Handle(GetEmployeeSalaryQuery request, CancellationToken cancellationToken)
    {
        var target = await _employeeSalaryRepository.GetByIdAsync(new(request.EmployeeSalaryId));

        if (target is null)
            return Result<EmployeeSalaryResponse>.NotFound(Errors.SalaryRecordNotFound);

        var resultValue = target.ToDto();

        return Result<EmployeeSalaryResponse>.Ok(resultValue);
    }
}
