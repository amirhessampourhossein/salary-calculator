using MediatR;
using SalaryCalculator.Application.Models;

namespace SalaryCalculator.Application.EmployeeSalaries.DeleteEmployeeSalary;

public class DeleteEmployeeSalaryCommandHandler(IEmployeeSalaryRepository employeeSalaryRepository)
    : IRequestHandler<DeleteEmployeeSalaryCommand, Result>
{
    public async Task<Result> Handle(DeleteEmployeeSalaryCommand request, CancellationToken cancellationToken)
    {
        await employeeSalaryRepository.DeleteAsync(request.EmployeeSalaryId);

        return Result.Success(Result.SuccessMessages.Delete);
    }
}
