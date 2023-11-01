using MediatR;
using SalaryCalculator.Application.Models;

namespace SalaryCalculator.Application.EmployeeSalaries.GetRangeEmployeeSalaries;

public record GetRangeEmployeeSalaryQuery(string StartDate, string EndDate) : IRequest<Result<IReadOnlyList<EmployeeSalaryDto>>>;
