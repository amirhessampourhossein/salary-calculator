using MediatR;

namespace SalaryCalculator.Application.EmployeeSalary.AddEmployeeSalary;

public record AddEmployeeSalaryCommand(string Data, string OvertimeCalculator) : IRequest;
