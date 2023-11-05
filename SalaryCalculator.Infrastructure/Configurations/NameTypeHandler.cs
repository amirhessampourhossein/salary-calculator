using Dapper;
using SalaryCalculator.Domain.EmployeeSalaries;
using System.Data;

namespace SalaryCalculator.Infrastructure.Configurations;

public class NameTypeHandler : SqlMapper.TypeHandler<Name>
{
    public override Name? Parse(object value) => new(value.ToString());

    public override void SetValue(IDbDataParameter parameter, Name? value)
    {
        parameter.DbType = DbType.String;
        parameter.Value = value;
    }
}
