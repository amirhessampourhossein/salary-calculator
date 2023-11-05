using System.Net;

namespace SalaryCalculator.Application.Exceptions;

public class FailedToMapStringException : ExceptionBase
{
    public FailedToMapStringException()
        : base("Failed to map the data string", HttpStatusCode.BadRequest)
    {
    }
}
