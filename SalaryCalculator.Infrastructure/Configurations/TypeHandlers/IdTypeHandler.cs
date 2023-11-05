using Dapper;
using SalaryCalculator.Domain.EmployeeSalaries;
using System.Data;

namespace SalaryCalculator.Infrastructure.Configurations.TypeHandlers;

public class IdTypeHandler : SqlMapper.TypeHandler<Id>
{
    public override Id? Parse(object value) => (Guid)value;

    public override void SetValue(IDbDataParameter parameter, Id? value)
    {
        parameter.DbType = DbType.Guid;
        parameter.Value = value;
    }
}
