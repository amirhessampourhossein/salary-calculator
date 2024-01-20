using MediatR;
using SalaryCalculator.Api.Requests;
using SalaryCalculator.Application.EmployeeSalaries.CreateEmployeeSalary;
using SalaryCalculator.Application.EmployeeSalaries.DeleteEmployeeSalary;
using SalaryCalculator.Application.EmployeeSalaries.GetEmployeeSalary;
using SalaryCalculator.Application.EmployeeSalaries.GetRangeEmployeeSalaries;
using SalaryCalculator.Application.EmployeeSalaries.UpdateEmployeeSalary;

namespace SalaryCalculator.Api.Endpoints;

public static class EmployeeSalaryEndpoints
{
    public static void MapEmployeeSalaryEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/salary");

        group.MapPost("/{datatype}", CreateEmployeeSalary)
            .WithName(nameof(CreateEmployeeSalary))
            .WithOpenApi();

        group.MapPut("/{datatype}/{id}", UpdateEmployeeSalary)
            .WithName(nameof(UpdateEmployeeSalary))
            .WithOpenApi();

        group.MapDelete("/{id}", DeleteEmployeeSalary)
            .WithName(nameof(DeleteEmployeeSalary))
            .WithOpenApi();

        group.MapGet("/{id}", GetEmployeeSalary)
            .WithName(nameof(GetEmployeeSalary))
            .WithOpenApi();

        group.MapGet("/", GetEmployeeSalaries)
            .WithName(nameof(GetEmployeeSalaries))
            .WithOpenApi();
    }

    public static async Task<IResult> CreateEmployeeSalary(ISender sender, string dataType, EmployeeSalaryOvertimeRequestBody request)
    {
        var result = await sender.Send(new CreateEmployeeSalaryCommand(
                request.Data,
                dataType,
                request.OvertimeCalculator));

        return TypedResults.Created($"/api/salary/{(Guid)result.Data}", result);
    }

    public static async Task<IResult> UpdateEmployeeSalary(ISender sender, string dataType, Guid id, EmployeeSalaryOvertimeRequestBody request)
    {
        var result = await sender.Send(new UpdateEmployeeSalaryCommand(
                id,
                request.Data,
                dataType,
                request.OvertimeCalculator));

        return TypedResults.Ok(result);
    }

    public static async Task<IResult> DeleteEmployeeSalary(ISender sender, Guid id)
    {
        var result = await sender.Send(new DeleteEmployeeSalaryCommand(id));

        return TypedResults.Ok(result);
    }

    public static async Task<IResult> GetEmployeeSalary(ISender sender, Guid id)
    {
        var result = await sender.Send(new GetEmployeeSalaryQuery(id));

        return TypedResults.Ok(result);
    }

    public static async Task<IResult> GetEmployeeSalaries(ISender sender, string startDate, string endDate)
    {
        var result = await sender.Send(new GetRangeEmployeeSalaryQuery(startDate, endDate));

        return TypedResults.Ok(result);
    }
}
