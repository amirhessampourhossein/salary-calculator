using System.Net;

namespace SalaryCalculator.Application.Exceptions;

public class InvalidPersianDateException : ExceptionBase
{
    public InvalidPersianDateException()
        : base("Input date is invalid", HttpStatusCode.BadRequest)
    {
    }
}
