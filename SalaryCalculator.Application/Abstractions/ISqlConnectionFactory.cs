using System.Data;

namespace SalaryCalculator.Application.Abstractions;

public interface ISqlConnectionFactory
{
    IDbConnection CreateConnection();
}
