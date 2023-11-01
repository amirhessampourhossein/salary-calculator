namespace SalaryCalculator.Application.EmployeeSalaries;

public class EmployeeSalaryDto
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public decimal BasicSalary { get; set; }
    public decimal Allowance { get; set; }
    public decimal Transportation { get; set; }
    public DateTime Date { get; set; }
}
