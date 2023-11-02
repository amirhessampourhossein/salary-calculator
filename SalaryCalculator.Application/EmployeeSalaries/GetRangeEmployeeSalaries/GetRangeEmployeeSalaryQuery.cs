using MediatR;
using SalaryCalculator.Application.Models;

namespace SalaryCalculator.Application.EmployeeSalaries.GetRangeEmployeeSalaries;

public record GetRangeEmployeeSalaryQuery(string PersianStartDate, string PersianEndDate) : IRequest<Result<IReadOnlyList<EmployeeSalaryResponse>>>;
