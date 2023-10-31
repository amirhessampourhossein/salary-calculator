using MediatR;
using SalaryCalculator.Application.Models;

namespace SalaryCalculator.Application.EmployeeSalaries.GetRangeEmployeeSalaries;

public record GetRangeEmployeeSalaryQuery(DateRange DateRange) : IRequest<Result>;
