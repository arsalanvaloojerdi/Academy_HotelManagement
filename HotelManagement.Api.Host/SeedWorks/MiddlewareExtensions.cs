using Microsoft.AspNetCore.Builder;

namespace HotelManagement.Api.Host.SeedWorks
{
    public static class MiddlewareExtensions
    {
        public static void UseApiExceptionHandler(this IApplicationBuilder app)
        {
            app.UseMiddleware<ApiExceptionHandlerMiddleware>();
        }
    }
}