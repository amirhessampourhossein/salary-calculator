using System.Net;

namespace SalaryCalculator.Application.Exceptions;

public class EntryNotFoundException : ExceptionBase
{
    public EntryNotFoundException()
        : base("No entry was found in the database", HttpStatusCode.NotFound)
    {
    }
}
