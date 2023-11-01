using MediatR;
using Microsoft.AspNetCore.Mvc;
using SalaryCalculator.Application;
using SalaryCalculator.Application.EmployeeSalaries.AddEmployeeSalary;
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

group.MapPost("/", async (ISender sender, [FromBody] AddEmployeeSalaryCommand request) =>
{
    var result = await sender.Send(request);
});

app.Run();
