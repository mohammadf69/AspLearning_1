

using System;
using AspLearning_1.Binder;
using AspLearning_1.Context;
using AspLearning_1.InterFaces;
using AspLearning_1.MiddelWares;
using AspLearning_1.Services;
using Serilog;
using ElmahCore.Mvc;
using ElmahCore.Sql;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.WebUtilities;
using StackExchange.Redis;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using AspLearning_1.MiddelWares;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews(option =>
{
    //add new provider
    option.ModelBinderProviders.Insert(0,new CourseBinderProvider());
});
var logger = new LoggerConfiguration().MinimumLevel.Debug().WriteTo.Console().WriteTo
    .File("Logs/log-.txt", rollingInterval: RollingInterval.Day).CreateLogger();

 

builder.Services.AddTransient<IUnitOfWork,UnitOfWork>();
builder.Services.AddElmah<SqlErrorLog>(opt =>
        {
            opt.Path = "elmah";
            opt.ConnectionString =
                "Server=.;DataBase=ASpNETCoreLearning_Log;User ID =MOHAMAMD; Trusted_Connection=True; MultipleActiveResultSets=True;";
        }
    );
builder.Host.UseSerilog();
builder.Services.AddResponseCaching();
builder.Services.AddOutputCache();
builder.Services.AddTransient<CustomeMidelware>();
builder.Services.AddTransient<ConvenstionlMiddelWare>();
//Redis Configuration
builder.Services.AddSingleton<IConnectionMultiplexer>(sp =>
{
    var configuration = ConfigurationOptions.Parse("localhost:6379", true);
    return ConnectionMultiplexer.Connect(configuration);
});

//ADD DB Connection
builder.Services.AddDbContext<Mycontext>(options =>
    {
        options.UseQueryTrackingBehavior(QueryTrackingBehavior.TrackAll);
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    });
var conn = builder.Configuration.GetConnectionString("DefaultConnection");
Console.WriteLine($"Connection String: {conn}");


var app = builder.Build();

try
{
    Log.Information("staing Web Host");

}
catch (Exception e)
{
  Log.Fatal(e,"application Start-up failed");
}
finally
{
    Log.CloseAndFlush();
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();
app.UseResponseCaching();
app.UseAuthorization();
app.UseElmah();
app.UseOutputCache();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

//app.UseEndpoints(Endpoint =>
//{
//    Endpoint.Map("file/{fileName}.{exteion}", async (context) =>
//    {
//        await context.Response.WriteAsync("This is File");
//    });
//});

app.UseEndpoints(endpoints =>
{
    endpoints.Map("Employy/Profile/{USerName:bool}", async context =>
    {
        var fileName = context.Request.RouteValues["USerName"];

        await context.Response.WriteAsync($"File Requested: {fileName}");
    });
    endpoints.Map("Products/SaleLoadBarCode/{ID:int:min(1):max(10)}", async(contxt) =>
    {
        var id = contxt.Request.RouteValues["ID"]??5;
        await contxt.Response.WriteAsync($"id => {id}");
    });
    //endpoints.Map("Products/SaleLoadBarCode/{ID?}", async (contxt) =>
    //{
    //    var id = contxt.Request.RouteValues["ID"];
    //    await contxt.Response.WriteAsync($"id => {id}");
    //});

});

//app.Use(async (context, @delegate) =>
//{
//    //Before Logic
//    await @delegate(context);
//    await context.Response.WriteAsync("MidelWare Eins");
//    //After Logic
//    await context.Response.WriteAsync("MidelWare Eins-Nach");
//});
//app.Use(async (HttpContext context, RequestDelegate next) =>
//{
//    //BEforeRequest
//    await context.Response.WriteAsync("MiddelWare zwei");
//    await next(context);
//    await context.Response.WriteAsync("MiddelWare zwei-Nach");
//    //Next To the Request
//});
//app.UseMiddleware<CustomeMidelware>();
//app.UseMycustomeMiddelWare();
//app.UseMiddleware<ConvenstionlMiddelWare>();
//app.useConvenstionlMiddelWare();
app.UseWhen(context => context.Request.Query.ContainsKey("username"), ApplicationBuilder =>
{
    ApplicationBuilder.Use(async (context, @delegate) =>
    {
        await context.Response.WriteAsync("USeWhen");
        await @delegate();
    });
});
//app.Run(async context =>
//    {
//        await context.Response.WriteAsync("  =>  3");

//        //End of Request

//    }

//);
app.Run();
