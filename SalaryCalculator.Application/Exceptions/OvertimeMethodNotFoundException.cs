using System.Net;

namespace SalaryCalculator.Application.Exceptions;

public class OvertimeMethodNotFoundException : ExceptionBase
{
    public OvertimeMethodNotFoundException()
        : base("Could not find the requested overtime method", HttpStatusCode.NotFound)
    {
    }
}
