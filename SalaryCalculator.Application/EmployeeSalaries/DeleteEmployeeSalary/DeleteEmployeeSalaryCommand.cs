using MediatR;
using SalaryCalculator.Application.Models;

namespace SalaryCalculator.Application.EmployeeSalaries.DeleteEmployeeSalary;

public record DeleteEmployeeSalaryCommand(Guid EmployeeSalaryId) : IRequest<Result>;
