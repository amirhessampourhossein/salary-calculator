namespace SalaryCalculator.Application.EmployeeSalaries;

/// <summary>
/// This class is used in <br/>
/// <see cref="IEmployeeSalaryRepository.GetByIdAsync"></see> and <br/>
/// <see cref="IEmployeeSalaryRepository.GetByDateRangeAsync"/> methods <br/>
/// to return the fetched entries to presentation
/// </summary>
public class EmployeeSalaryResponse
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public decimal BasicSalary { get; set; }
    public decimal Allowance { get; set; }
    public decimal Transportation { get; set; }
    public decimal TotalSalary { get; set; }
    public DateTime Date { get; set; }
}
