using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using SendGrid.Helpers.Errors.Model;
using System.ComponentModel.DataAnnotations;

namespace Banking_API.Application.Exceptions
{
    public class ExceptionMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext httpcontext, RequestDelegate next)
        {
            try
            {
                await next(httpcontext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpcontext, ex);
            }
        }
        private static Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
        {
            int statusCode = GetStatusCode(exception);
            httpContext.Response.StatusCode = statusCode;
            httpContext.Response.ContentType = "application/json";

            List<string> errors = new()
            {
                exception.Message,
                exception.InnerException?.ToString()
            };

            return httpContext.Response.WriteAsync(new ExceptionModel
            {
                Errors = errors,
                StatusCode = statusCode

            }.ToString()) ;

        }
        private static int GetStatusCode(Exception exception) =>
            exception switch
            {
                BadHttpRequestException=>StatusCodes.Status400BadRequest,
                NotFoundException => StatusCodes.Status404NotFound,
                ValidationException =>StatusCodes.Status422UnprocessableEntity,
                _=>StatusCodes.Status500InternalServerError
            };
        
    }
}
