using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
            httpContext.Response.ContentType = "application/json";

            if(exception is NotFoundException notFoundException)
            {
                return createNotFoundProblemDetailsResponse(httpContext, notFoundException,statusCode);
            }
            if (exception is BadRequestException badRequestException)
            {
                return createBadRequestProblemDetailsResponse(httpContext, badRequestException, statusCode);
            }
            if(exception is BusinessException businessException)
            {
                return createBusinessProblemDetailsResponse(httpContext, businessException, statusCode);
            }

            return createInternalProblemDetailResponse(httpContext, exception, statusCode);

        }
        private static int GetStatusCode(Exception exception) =>
            exception switch
            {
                BadRequestException=>StatusCodes.Status400BadRequest,
                NotFoundException => StatusCodes.Status404NotFound,
                BusinessException => StatusCodes.Status400BadRequest,
                UserCreateFailedException=>StatusCodes.Status400BadRequest,
                ValidationException =>StatusCodes.Status422UnprocessableEntity,
                _=>StatusCodes.Status500InternalServerError
         };
        private static Task createNotFoundProblemDetailsResponse(HttpContext httpContext, NotFoundException notFoundException,int statusCode)
        {
            httpContext.Response.StatusCode = statusCode;
            NotFoundProblemDetails notFoundProblemDetails = new NotFoundProblemDetails()
            {
                Type="Not Found",
                Title = "NotFound Exception",
                Status = statusCode,
                Detail = notFoundException.Message,
                Instance = httpContext.Request.Path
            };
            return httpContext.Response.WriteAsync(notFoundProblemDetails.ToString());
        }
        private static Task createBadRequestProblemDetailsResponse(HttpContext httpContext, BadRequestException badRequestException, int statusCode)
        {
            httpContext.Response.StatusCode = statusCode;
            BadRequestExceptionDetails badRequestExceptionDetails = new BadRequestExceptionDetails()
            {
                Type = "Bad Request",
                Title = "BadRequest Exception",
                Status = statusCode,
                Detail=badRequestException.Message,
                Instance = httpContext.Request.Path
            };
            return httpContext.Response.WriteAsync(badRequestExceptionDetails.ToString());
        }
        private static Task createInternalProblemDetailResponse(HttpContext httpContext, Exception exception, int statusCode)
        {
            httpContext.Response.StatusCode = statusCode;
            ProblemDetails problemDetails = new()
            {
                Type = "Internal Server",
                Title = "Internal Server Exception",
                Status = statusCode,
                Detail = exception.Message,
                Instance = httpContext.Request.Path
            };
            return httpContext.Response.WriteAsync(JsonConvert.SerializeObject(problemDetails));
        }
        private static Task createBusinessProblemDetailsResponse(HttpContext httpContext, BusinessException businessException,int statusCode)
        {
            httpContext.Response.StatusCode =statusCode;
            BusinessExceptionDetails businessExceptionDetails = new BusinessExceptionDetails()
            {
                Type= "Business",
                Title = "Business Exception",
                Status = statusCode,
                Detail = businessException.Message,
                Instance = httpContext.Request.Path
            };
            return httpContext.Response.WriteAsync(businessExceptionDetails.ToString());
        }
        private static Task createUserCreateFailedDetailsResponse(HttpContext httpContext, UserCreateFailedException userCreateFailedException, int statusCode)
        {
            httpContext.Response.StatusCode = statusCode;
            UserCreateFailedDetails userCreateFailedDetails = new UserCreateFailedDetails()
            {
                Type = "User Create Fail",
                Title = "User Create Failed Exception",
                Status = statusCode,
                Detail = userCreateFailedException.Message,
                Instance = httpContext.Request.Path
            };
            return httpContext.Response.WriteAsync(userCreateFailedDetails.ToString());
        }

    }
}
