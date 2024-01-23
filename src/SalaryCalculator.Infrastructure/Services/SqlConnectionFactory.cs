using Microsoft.Data.SqlClient;
using SalaryCalculator.Application.Abstractions;
using System.Data;

namespace SalaryCalculator.Infrastructure.Services;

public class SqlConnectionFactory(string connectionString)
    : ISqlConnectionFactory
{
    public IDbConnection CreateConnection()
    {
        var connection = new SqlConnection(connectionString);
        connection.Open();

        return connection;
    }
}
