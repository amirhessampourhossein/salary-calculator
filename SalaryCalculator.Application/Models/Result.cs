namespace SalaryCalculator.Application.Models;

public class Result
{
    public bool IsSuccess { get; init; }
    public string Message { get; init; } = string.Empty;
    public dynamic? Data { get; init; }

    public static Result Success(string message = "") => new()
    {
        IsSuccess = true,
        Message = message
    };
    public static Result Success<TData>(TData data, string message = "") => new()
    {
        IsSuccess = true,
        Message = message,
        Data = data
    };
    public static Result Failure(string message = "") => new()
    {
        IsSuccess = false,
        Message = message
    };

    public static class SuccessMessages
    {
        public const string Create = "Added Successfully";
        public const string Read = "Fetched Successfully";
        public const string Update = "Updated Successfully";
        public const string Delete = "Removed Successfully";
    }
}
