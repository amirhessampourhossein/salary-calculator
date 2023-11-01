using MediatR;
using SalaryCalculator.Application.Abstractions;
using SalaryCalculator.Application.Models;
using SalaryCalculator.Domain.EmployeeSalaries;

namespace SalaryCalculator.Application.EmployeeSalaries.DeleteEmployeeSalary;

public class DeleteEmployeeSalaryCommandHandler : IRequestHandler<DeleteEmployeeSalaryCommand, Result>
{
    private readonly IRepository<EmployeeSalary, EmployeeSalaryId> _employeeSalaryRepository;

    public DeleteEmployeeSalaryCommandHandler(IRepository<EmployeeSalary, EmployeeSalaryId> employeeSalaryRepository)
    {
        _employeeSalaryRepository = employeeSalaryRepository;
    }

    public async Task<Result> Handle(DeleteEmployeeSalaryCommand request, CancellationToken cancellationToken)
    {
        var deletedId = await _employeeSalaryRepository.DeleteAsync(
            new EmployeeSalaryId(request.EmployeeSalaryId),
            cancellationToken);

        if (deletedId is null)
            return Result.Failure(Errors.NotFound);

        return Result.Success(deletedId.Value);
    }
}
