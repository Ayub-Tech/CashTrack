using System.Net;

namespace CashTrack.Api.Middlewares
{
    // This middleware handles unexpected errors globally
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        // Constructor that gets the next middleware in the pipeline
        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        // This method is called for every HTTP request
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                // Continue to the next middleware or controller
                await _next(context);
            }
            catch (Exception)
            {
                // If an error occurs, return status code 500
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                // Return a simple error message to the client
                await context.Response.WriteAsync("Something went wrong.");
            }
        }
    }
}