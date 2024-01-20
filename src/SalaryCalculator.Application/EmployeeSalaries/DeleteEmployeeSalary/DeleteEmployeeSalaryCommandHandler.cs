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
        await _employeeSalaryRepository.DeleteAsync(request.EmployeeSalaryId);

        return Result.Success(Result.SuccessMessages.Delete);
    }
}
