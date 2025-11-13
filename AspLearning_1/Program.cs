

using AspLearning_1.Context;
using AspLearning_1.InterFaces;
using AspLearning_1.Services;
using Serilog;
using ElmahCore.Mvc;
using ElmahCore.Sql;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
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
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
