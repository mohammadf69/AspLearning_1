using ControllerCourse.Json;
using ControllerCourse.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace ControllerCourse.Controller;

public class HomeController:Microsoft.AspNetCore.Mvc.Controller
{
    //[Route("/")]
    ////Rout
    //[Route("Index/{pageId:int?}/{searchBy}")]
    ////query string
    //[Route("Index")]
    ////query string =http://localhost:43062/Index/?pageId=10&searchby=MOhammadFatahi
    ////Route Data =http://localhost:43062/Index/10/MOhammadFatahi
    ////MIx =http://localhost:43062/Index/1?&searchBy=d


    //query string
    public IActionResult IndexQueryString([FromQuery]int? pageId  , [FromQuery] string searchBy)
    {

        return this.Content($"Page ID is => {pageId} & SearchBy => {searchBy}");

    }
    //Rout
    public IActionResult IndexRout([FromRoute] int? pageId, [FromRoute] string searchBy)
    {

        return this.Content($"Page ID is => {pageId} & SearchBy => {searchBy}");

    }
    //FromRoute
    [Route("/")]
    [Route("IndexParameters/{pageId:int?}/{searchBy}")]
    //query string
    [Route("/")]
    [Route("IndexParameters")]
    //query string


    public IActionResult IndexParameters(IndexParameters indexParameters)
    {

        return this.Content($"Page ID is => {indexParameters.PageId} & SearchBy => {indexParameters.SearchBy}");

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