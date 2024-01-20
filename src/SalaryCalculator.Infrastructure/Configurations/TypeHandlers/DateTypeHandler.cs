using Dapper;
using SalaryCalculator.Domain.EmployeeSalaries;
using System.Data;

namespace SalaryCalculator.Infrastructure.Configurations.TypeHandlers;

public class DateTypeHandler : SqlMapper.TypeHandler<Date>
{
    public override Date? Parse(object value) => DateOnly.FromDateTime((DateTime)value);

    public override void SetValue(IDbDataParameter parameter, Date? value)
    {
        parameter.DbType = DbType.Date;
        parameter.Value = value;
    }
}
