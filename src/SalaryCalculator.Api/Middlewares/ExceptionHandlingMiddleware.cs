﻿using SalaryCalculator.Application.Exceptions;
using SalaryCalculator.Application.Models;
using System.Net;

namespace SalaryCalculator.Api.Middlewares
{
    public class ExceptionHandlingMiddleware(RequestDelegate next)
    {
        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await next(httpContext);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionBase exceptionBase)
                {
                    httpContext.Response.StatusCode = (int)exceptionBase.StatusCode;

                    await httpContext.Response.WriteAsJsonAsync(Result.Failure(exceptionBase.Message));

                    return;
                }

                httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                await httpContext.Response.WriteAsJsonAsync(Result.Failure(ex.Message));
            }
        }
    }

    public static class ExceptionHandlingMiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionHandlingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandlingMiddleware>();
        }
    }
}
