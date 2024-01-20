using System.Net;

namespace SalaryCalculator.Application.Exceptions;

public class FailedToCreateFormatMapperException : ExceptionBase
{
    public FailedToCreateFormatMapperException() :
        base("Failed to create an appropriate mapper for the given data type", HttpStatusCode.BadRequest)
    {
    }
}
