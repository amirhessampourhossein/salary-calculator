using MediatR;
using SalaryCalculator.Application.Models;

namespace SalaryCalculator.Application.EmployeeSalaries.AddEmployeeSalary;

public record AddEmployeeSalaryCommand(string Data, string OvertimeCalculator) : IRequest<Result>;
