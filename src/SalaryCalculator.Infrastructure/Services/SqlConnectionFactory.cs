using Microsoft.Data.SqlClient;
using SalaryCalculator.Application.Abstractions;
using System.Data;

namespace SalaryCalculator.Infrastructure.Services;

public class SqlConnectionFactory : ISqlConnectionFactory
{
    private readonly string _connectionString;

    public SqlConnectionFactory(string connectionString)
    {
        _connectionString = connectionString;
    }

    public IDbConnection CreateConnection()
    {
        var connection = new SqlConnection(_connectionString);
        connection.Open();

        return connection;
    }
}
