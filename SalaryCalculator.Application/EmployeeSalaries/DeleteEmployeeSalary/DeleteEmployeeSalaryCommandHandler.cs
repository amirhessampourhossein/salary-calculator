using MediatR;
using SalaryCalculator.Application.Models;

namespace SalaryCalculator.Application.EmployeeSalaries.DeleteEmployeeSalary;

public class DeleteEmployeeSalaryCommandHandler : IRequestHandler<DeleteEmployeeSalaryCommand, Result>
{
    private readonly IEmployeeSalaryRepository _employeeSalaryRepository;

    public DeleteEmployeeSalaryCommandHandler(IEmployeeSalaryRepository employeeSalaryRepository)
    {
        _employeeSalaryRepository = employeeSalaryRepository;
    }

    public async Task<Result> Handle(DeleteEmployeeSalaryCommand request, CancellationToken cancellationToken)
    {
        var target = await _employeeSalaryRepository.GetByIdAsync(new(request.EmployeeSalaryId));

        if (target is null)
            return Result.NotFound(Errors.SalaryRecordNotFound);

        await _employeeSalaryRepository.DeleteAsync(target);

        return Result.Ok(Messages.SuccessfulDelete);
    }
}
