using ControllerCourse.Json;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using Microsoft.AspNetCore.Http.HttpResults;

namespace ControllerCourse.Controller;

public class HomeController:Microsoft.AspNetCore.Mvc.Controller
{
    [Route("/")]
    [Route("Index")]
    public JsonResult Index()
    {
        ////return new  ContentResult()
        ////{
        ////    ContentType = "Text/plain",
        ////    StatusCode = 200,
        ////    Content = " das Ist mein Computer"
        ////};
        //return Content("<h1> das ist einen Inhalt </h1>","text/html" ,Encoding.UTF8);
        var country = new Country { Id = 1, Title = "Germany", Desc = "Deutch Land" };

        return new JsonResult(country);


    }
    public IActionResult Index1()
    {
        
        //Virtual wwwRoot In Project
        return new VirtualFileResult("Sample.pdf","application/Pdf");
        return  File("Sample.pdf","application/Pdf");
        //physical Address Out Project
        return new PhysicalFileResult("@c:/1/1", "Application/pdf");
        return  PhysicalFile("@c:/1/1", "Application/pdf");
        //File Content Result : Out Project
        byte[] bytes = System.IO.File.ReadAllBytes("@c:/1/1");
        return new FileContentResult(bytes,"Application/Pdf");



    }

    public IActionResult Test()
    {
        //eror 400
        return new BadRequestResult();
        return this.BadRequest();
    }
    public IActionResult Test1()
    {
        //eror 404
        return new NotFoundResult();
        return this.NotFound();
    }
    public IActionResult Test2()
    {
        //eror 401
        return new UnauthorizedResult();
        return this.Unauthorized();
    }

    public IActionResult Test3()
    {
        
        return StatusCode(404, "NotFound");
    }


    [Route("About")]
    public string About()
    {
        return "About";
    }
    [Route("Contact")]
    public string Contact()
    {
        return "Contact";

    }

}