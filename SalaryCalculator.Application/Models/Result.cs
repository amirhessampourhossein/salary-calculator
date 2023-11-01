using System.Net;

namespace SalaryCalculator.Application.Models;

public class Result<TData>
{
    public bool IsSuccess { get; init; }
    public HttpStatusCode StatusCode { get; init; }
    public string Message { get; init; } = string.Empty;
    public TData? Data { get; init; }

    public static Result<TData> Ok(string message) => new()
    {
        IsSuccess = true,
        StatusCode = HttpStatusCode.OK,
        Message = message
    };
    public static Result<TData> Ok(TData data) => new()
    {
        IsSuccess = true,
        StatusCode = HttpStatusCode.OK,
        Data = data
    };
    public static Result<TData> Created(TData data) => new()
    {
        IsSuccess = true,
        StatusCode = HttpStatusCode.Created,
        Data = data
    };
    public static Result<TData> Created(TData data, string message) => new()
    {
        IsSuccess = true,
        StatusCode = HttpStatusCode.Created,
        Data = data,
        Message = message
    };
    public static Result<TData> NotFound(string message) => new()
    {
        IsSuccess = false,
        StatusCode = HttpStatusCode.NotFound,
        Message = message
    };
    public static Result<TData> BadRequest(string message) => new()
    {
        IsSuccess = false,
        StatusCode = HttpStatusCode.BadRequest,
        Message = message
    };
}

public static class Errors
{
    public const string CouldNotMapData = "Could not map the data string";
    public const string SalaryRecordNotFound = "Could not find any salary record with the received id";
    public const string SalaryRecordNotFoundInRange = "Could not find any salary record within the date range";
    public const string OvertimeMethodNotFound = "Could not find the requested overtime method";
}

public static class Messages
{
    public const string SuccessfulCreate = "successfully added the new employee salary";
    public const string SuccessfulUpdate = "successfully updated employee salary";
    public const string SuccessfulDelete = "successfully deleted employee salary";
}
