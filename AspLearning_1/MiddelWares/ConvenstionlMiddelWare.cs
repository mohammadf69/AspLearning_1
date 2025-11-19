using Microsoft.AspNetCore.Builder;

namespace AspLearning_1.MiddelWares;

    public  class ConvenstionlMiddelWare : IMiddleware
{
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync("Conventional");
            await next(context);
    }
}

    public static class Convenstion
    {
        public static IApplicationBuilder useConvenstionlMiddelWare(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ConvenstionlMiddelWare>();

        }
    }



