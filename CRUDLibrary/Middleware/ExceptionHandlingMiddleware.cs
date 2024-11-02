
using Application.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace CRUDLibrary.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try 
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                var exceptionDetails = GetExceptionDetails(ex);
                var problemdDetails = new ProblemDetails
                {
                    Status = exceptionDetails.Status,
                    Type = exceptionDetails.Type,  
                    Title = exceptionDetails.Title,
                    Detail = exceptionDetails.Details
                };
                if(exceptionDetails.Details is not null)
                {
                    problemdDetails.Extensions["errors"] = exceptionDetails.Errors;
                }
                context.Response.StatusCode = exceptionDetails.Status;
                await context.Response.WriteAsJsonAsync(problemdDetails);
            }
        }
        private static ExceptionDetails GetExceptionDetails(Exception exception)
        {
            return exception switch
            {
                ValidationException validationException => new ExceptionDetails(
                    StatusCodes.Status400BadRequest,
                    "Validation Failure",
                    "Validation error",
                    "One or more validation errors has occured",
                    validationException.Errors),
                _ => new ExceptionDetails(
                    StatusCodes.Status500InternalServerError,
                    "ServerError",
                    "Server error",
                    "An unexpected error has occured",
                    null)
            };
        }
    }
    internal record ExceptionDetails(int Status, string Type, string Title, string Details, IEnumerable<object>? Errors );
}
