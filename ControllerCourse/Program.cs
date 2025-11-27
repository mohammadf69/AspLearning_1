var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();//Razor page Mvc
var app = builder.Build();
//Controller => Class => Group Action => Handling Your Request
//Action => EndPoint => URl => EndPoint => action => Run => Response
//app.MapGet("/", () => "Hello World!");
app.MapControllers();//Used Active Routing Controller
app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
app.Run();
