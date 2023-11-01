using MediatR;
using SalaryCalculator.Application.Models;

namespace SalaryCalculator.Application.EmployeeSalaries.DeleteEmployeeSalary;

public class DeleteEmployeeSalaryCommandHandler : IRequestHandler<DeleteEmployeeSalaryCommand, Result<Guid?>>
{
    private readonly IEmployeeSalaryRepository _employeeSalaryRepository;

    public DeleteEmployeeSalaryCommandHandler(IEmployeeSalaryRepository employeeSalaryRepository)
    {
        _employeeSalaryRepository = employeeSalaryRepository;
    }

    public async Task<Result<Guid?>> Handle(DeleteEmployeeSalaryCommand request, CancellationToken cancellationToken)
    {
        var target = await _employeeSalaryRepository.GetByIdAsync(new(request.EmployeeSalaryId));

        if (target is null)
            return Result<Guid?>.NotFound(Errors.SalaryRecordNotFound);

        await _employeeSalaryRepository.DeleteAsync(target);

        return Result<Guid?>.Ok(Messages.SuccessfulDelete);
    }
}
