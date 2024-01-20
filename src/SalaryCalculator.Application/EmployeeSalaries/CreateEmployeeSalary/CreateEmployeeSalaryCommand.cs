using MediatR;
using SalaryCalculator.Application.Models;

namespace SalaryCalculator.Application.EmployeeSalaries.CreateEmployeeSalary;

public record CreateEmployeeSalaryCommand(string Data, string DataType, string OvertimeCalculator) : IRequest<Result>;
