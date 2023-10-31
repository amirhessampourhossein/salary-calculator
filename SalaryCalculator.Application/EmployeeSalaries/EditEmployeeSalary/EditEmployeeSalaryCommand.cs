using MediatR;
using SalaryCalculator.Application.Models;

namespace SalaryCalculator.Application.EmployeeSalaries.EditEmployeeSalary;

public record EditEmployeeSalaryCommand(Guid EmployeeSalaryId, string Data) : IRequest<Result>;
