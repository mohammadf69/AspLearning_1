using System.Diagnostics;
using AspLearning_1.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspLearning_1.Controllers
{
    using AspLearning_1.Context;
    using AspLearning_1.Entites;
    using AspLearning_1.InterFaces;

    using Microsoft.EntityFrameworkCore;

    public class HomeController() : Controller
    {

       
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()  
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
