using SalaryCalculator.Api.Endpoints;
using SalaryCalculator.Api.Middlewares;
using SalaryCalculator.Application;
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

app.UseExceptionHandlingMiddleware();

app.MapEmployeeSalaryEndpoints();

app.Run();
