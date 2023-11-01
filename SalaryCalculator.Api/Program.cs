using MediatR;
using SalaryCalculator.Api.Requests;
using SalaryCalculator.Application;
using SalaryCalculator.Application.EmployeeSalaries.CreateEmployeeSalary;
using SalaryCalculator.Application.EmployeeSalaries.DeleteEmployeeSalary;
using SalaryCalculator.Application.EmployeeSalaries.GetEmployeeSalary;
using SalaryCalculator.Application.EmployeeSalaries.GetRangeEmployeeSalaries;
using SalaryCalculator.Application.EmployeeSalaries.UpdateEmployeeSalary;
using SalaryCalculator.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    app.Services.EnsureDatabaseCreated();
}

app.UseHttpsRedirection();

var group = app.MapGroup("/api/salary");

group.MapPost("/{datatype}", async (ISender sender, string dataType, EmployeeSalaryOvertimeRequestBody request) =>
{
    var result = await sender.Send(new CreateEmployeeSalaryCommand(
        request.Data,
        dataType,
        request.OvertimeCalculator));

    return TypedResults.Json(result, statusCode: (int)result.StatusCode);
});

group.MapPut("/{dataType}/{id}", async (ISender sender, string dataType, Guid id, EmployeeSalaryOvertimeRequestBody request) =>
{
    var result = await sender.Send(new UpdateEmployeeSalaryCommand(
        id,
        request.Data,
        dataType,
        request.OvertimeCalculator));

    return TypedResults.Json(result, statusCode: (int)result.StatusCode);
});

group.MapDelete("/{id}", async (ISender sender, Guid id) =>
{
    var result = await sender.Send(new DeleteEmployeeSalaryCommand(id));

    return TypedResults.Json(result, statusCode: (int)result.StatusCode);
});

group.MapGet("/{id}", async (ISender sender, Guid id) =>
{
    var result = await sender.Send(new GetEmployeeSalaryQuery(id));

    return TypedResults.Json(result, statusCode: (int)result.StatusCode);
});

group.MapGet("/", async (ISender sender, string StartDate, string EndDate) =>
{
    var result = await sender.Send(new GetRangeEmployeeSalaryQuery(StartDate, EndDate));

    return TypedResults.Json(result, statusCode: (int)result.StatusCode);
});

app.Run();
