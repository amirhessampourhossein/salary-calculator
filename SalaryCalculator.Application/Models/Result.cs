namespace SalaryCalculator.Application.Models;

public class Result
{
    public bool IsSuccess => !Errors.Any();
    public List<string> Errors { get; init; } = new();
    public object? Data { get; set; }

    public static Result Success<T>(T data) => new()
    {
        Data = data
    };

    public static Result Failure(params string[] errors) => new()
    {
        Errors = errors.ToList()
    };
}

public static class Errors
{
    public const string FailedToMapData = "Could not map the data string";
    public const string NotFound = "Could not find any salary record with the received id";
    public const string NotFoundInRange = "Could not find any salary record within the date range";
    public const string OvertimeMethodNotFound = "Could not find the requested overtime method";
}
