using MediatR;
using SalaryCalculator.Application.Models;

namespace SalaryCalculator.Application.EmployeeSalaries.GetEmployeeSalary;

public record GetEmployeeSalaryQuery(Guid EmployeeSalaryId) : IRequest<Result<EmployeeSalaryDto>>;
