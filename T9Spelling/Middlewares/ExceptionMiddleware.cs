using Newtonsoft.Json;
using T9Spelling.Models;
using ILogger = Serilog.ILogger;

namespace T9Spelling.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.Error($"Exception was thrown: {ex}.");

                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Response.ContentType = "application/json";

            var kEx = ex as KeyNotFoundException;

            if (kEx != null)
                context.Response.StatusCode = StatusCodes.Status404NotFound;

            var errorModel = new ErrorModel
            {
                Code = context.Response.StatusCode,
                Message = kEx?.Message ?? "Something went wrong.",
            };

            await context.Response.WriteAsync(JsonConvert.SerializeObject(errorModel));
        }
    }
}
