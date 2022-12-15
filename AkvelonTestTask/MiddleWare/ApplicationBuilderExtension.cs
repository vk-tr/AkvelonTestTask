using Microsoft.AspNetCore.Builder;

namespace AkvelonTestTask.MiddleWare
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder AddGlobalErrorHandler(this IApplicationBuilder applicationBuilder)
            => applicationBuilder.UseMiddleware<GlobalExceptionHandler>();
    }
}