using FinancialGoals.Domain.Results;
using FinancialGoals.Domain.Results.Errors;
using Newtonsoft.Json;
using System.Net;

namespace FinancialGoals.Api.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
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

        private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            Console.WriteLine($"Exception: {exception.Message}");

            context.Response.StatusCode = exception.GetType().Name switch
            {
                "ArgumentException" => (int)HttpStatusCode.NotFound,
                "ArgumentNullException" => (int)HttpStatusCode.NotFound,
                _ => (int)HttpStatusCode.InternalServerError
            };
            var result = JsonConvert.SerializeObject(new Result().Failure(GenericErrors.InternalProblem(exception.Message)));
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(result);
        }
    }
}
