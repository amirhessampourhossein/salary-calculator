using MediatR;
using SalaryCalculator.Application.Models;

namespace SalaryCalculator.Application.EmployeeSalaries.UpdateEmployeeSalary;

public record UpdateEmployeeSalaryCommand(Guid EmployeeSalaryId, string Data, string DataType, string OvertimeMethod) : IRequest<Result>;
