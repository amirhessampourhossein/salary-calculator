using Dapper;
using SalaryCalculator.Domain.EmployeeSalaries;
using System.Data;

namespace SalaryCalculator.Infrastructure.Configurations.TypeHandlers;

public class MoneyTypeHandler : SqlMapper.TypeHandler<Money>
{
    public override Money? Parse(object value) => Convert.ToDecimal(value);

    public override void SetValue(IDbDataParameter parameter, Money? value)
    {
        parameter.DbType = DbType.Decimal;
        parameter.Value = value;
    }
}
