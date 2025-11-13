namespace AspLearning_1.Attrebutes;
using Microsoft.AspNetCore.Mvc.Filters;



public class MyExceptionAttribute:ActionFilterAttribute,IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context is not { ExceptionHandled: false, Exception: FormatException }) return;
        context.ExceptionHandled = true;
        context.HttpContext.Response.WriteAsync("<h1>Sorry</h1>"+context.Exception.Message);
    }
} 