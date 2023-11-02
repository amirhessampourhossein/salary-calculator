namespace SalaryCalculator.Application.EmployeeSalaries;

/// <summary>
/// this class is used to deserialize the string data and then map it to the respective entity
/// </summary>
public class EmployeeSalaryRequest
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public decimal BasicSalary { get; set; }
    public decimal Allowance { get; set; }
    public decimal Transportation { get; set; }
    public string Date { get; set; } = string.Empty;
}
