using MediatR;
using SalaryCalculator.Application.Models;

namespace SalaryCalculator.Application.EmployeeSalaries.GetEmployeeSalary;

public class GetEmployeeSalaryQueryHandler : IRequestHandler<GetEmployeeSalaryQuery, Result<EmployeeSalaryDto>>
{
    private readonly IEmployeeSalaryRepository _employeeSalaryRepository;

    public GetEmployeeSalaryQueryHandler(IEmployeeSalaryRepository employeeSalaryRepository)
    {
        _employeeSalaryRepository = employeeSalaryRepository;
    }

    public async Task<Result<EmployeeSalaryDto>> Handle(GetEmployeeSalaryQuery request, CancellationToken cancellationToken)
    {
        var target = await _employeeSalaryRepository.GetByIdAsync(new(request.EmployeeSalaryId));

        if (target is null)
            return Result<EmployeeSalaryDto>.NotFound(Errors.SalaryRecordNotFound);

        var resultValue = target.ToDto();

        return Result<EmployeeSalaryDto>.Ok(resultValue);
    }
}
