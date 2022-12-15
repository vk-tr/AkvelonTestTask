using System;
using System.Net;
using System.Threading.Tasks;
using AkvelonTestTask.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace AkvelonTestTask.MiddleWare
{
    public class GlobalExceptionHandler
    {
        private readonly RequestDelegate _next;

        public GlobalExceptionHandler(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            HttpStatusCode status;
            string stackTrace;
            string message;

            var exceptionType = exception.GetType();

            if (exceptionType == typeof(ValidationException))
            {
                message = exception.Message;
                status = HttpStatusCode.NotFound;
                stackTrace = exception.StackTrace;
            }
            else if (exceptionType == typeof(DbUpdateConcurrencyException))
            {
                message = exception.Message;
                status = HttpStatusCode.NotFound;
                stackTrace = exception.StackTrace;
            }
            else
            {
                status = HttpStatusCode.InternalServerError;
                message = exception.Message;
                stackTrace = exception.StackTrace;
            }

            var exceptionResult = JsonConvert.SerializeObject(
                new
                {
                    error = message,
                    stackTrace
                });

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int) status;

            return context.Response.WriteAsync(exceptionResult);
        }
    }
}