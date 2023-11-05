using Dapper;
using SalaryCalculator.Domain.EmployeeSalaries;
using System.Data;

namespace SalaryCalculator.Infrastructure.Configurations;

public class IdTypeHandler : SqlMapper.TypeHandler<Id>
{
    public override Id? Parse(object value) => new((Guid)value);

    public override void SetValue(IDbDataParameter parameter, Id? value)
    {
        parameter.DbType = DbType.Guid; 
        parameter.Value = value;
    }
}
