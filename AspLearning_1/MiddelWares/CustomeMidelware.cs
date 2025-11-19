using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace AspLearning_1.MiddelWares;

public class CustomeMidelware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        //BEforeRequest
        await context.Response.WriteAsync("  => MiddelWare 1");
        await next(context);
        await context.Response.WriteAsync(" =>  MiddelWare_after");
        //Next To the Request
    }


  

}

public static class MyCustomeMiddelWare
{
    public static IApplicationBuilder UseMycustomeMiddelWare(this IApplicationBuilder app)
    {
        return app.UseMiddleware<CustomeMidelware>();
    }
}
