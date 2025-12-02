using AspLearning_1.Context;
using AspLearning_1.Entites;
using AspLearning_1.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.OutputCaching;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspLearning_1.Controllers
{
    using AspLearning_1.Attrebutes;
    using AspLearning_1.Binder;
    using AspLearning_1.InterFaces;
    using AspLearning_1.Services;

    public class CoursesController(IUnitOfWork  uow ,IMemoryCache memoryCache,IDistributedCache cach) : Controller
    {

        private readonly ILogger<HomeController> _logger;
       
        private static string CachName = "Courses";

        //[ResponseCache(Duration = 60,Location = ResponseCacheLocation.Any,NoStore = false,VaryByHeader = "User-Agent",VaryByQueryKeys = new []{"Id","Name"})] //Handelded by Client LIke Memory Cache
        //[OutputCache(Duration = 60,PolicyName = "",VaryByQueryKeys = new []{"ProductId"})]//Use WebApi && Handeled By Server
        // GET: Courses
        public  async Task<IActionResult> Index()
        {
           
            var cacheOptions = new DistributedCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(20))
                .SetSlidingExpiration(TimeSpan.FromMinutes(2));
                var result = await cach.GetOrSetAsync<List<Course>>(CachName, () =>
                {
                    return Task.FromResult(uow.Context.Set<Course>().Include(x => x.Author).ToList());
                }
            );
            
            return View(result);

        }

        // GET: Courses/Details/5

        public  IActionResult Details(int? id)
        {
            var num = int.Parse(id.ToString());

            if (id == null) return NotFound();

            var course = uow.Context.Set<Course>().Include(x => x.Author)
                .FirstOrDefault(x => x.id == id);




            if (course == null) return NotFound();
    

            return View(course);
        }

        // GET: Courses/Create
        public IActionResult Create()
         {
            var authors = uow.Repository<Author>().GetAll();
            ViewData["AuthorId"] = new SelectList(authors, "Id", "Name");
            return View();
        }


        [HttpPost]
       
        public IActionResult Create([Bind(nameof(course.AuthorId),nameof(course.Author))] Course course)
            {
            if (uow.Repository<Course>().Any(x=>x.Titele == course.Titele))
            {
                ModelState.AddModelError("Titele", "Der Header wird von einem anderen Benutzer verwendet.");
                var authors = uow.Repository<Author>().GetAll();
                ViewData["AuthorId"] = new SelectList(authors, "Id", "Name");
                return this.View(course);
            }
            
           
            uow.Repository<Course>().Add(course);
            uow.Complete();
                // memoryCache.Remove("courses");
                cach.Remove(CachName);
            return RedirectToAction(nameof(Index));
        }

        // GET: Courses/Edit/5
        public  IActionResult Edit(int? id)
        {
            if (id == null) return NotFound();
            var course = uow.Repository<Course>().GetById(id.Value);

           
            if (course == null) return NotFound();

            ViewData["AuthorId"] = new SelectList(uow.Repository<Author>().GetAll(), "Id", "Name", course.AuthorId);
            return View(course);
        }

      
        [HttpPost]
        public IActionResult Edit(int id,Course course)
        {
            if (id != course.id) return NotFound();
            ViewData["AuthorId"] = new SelectList(uow.Repository<Author>().GetAll(), "Id", "Name", course.AuthorId);
            var Entity = course;
            if (Entity.Titele != course.Titele)
            {
                if (uow.Repository<Course>().Any(x=>x.Titele == course.Titele.Trim()))
                {
                    ViewData["AuthorId"] = new SelectList(uow.Repository<Author>().GetAll(), "Id", "Name", course.AuthorId);
                    ModelState.AddModelError("Titele", "Der Header wird von einem anderen Benutzer verwendet.");
                    return View(course);
                }
            }
            uow.Repository<Course>().Update(course);
            uow.Complete();

            return RedirectToAction(nameof(this.Index));
        }

        // GET: Courses/Delete/5
        public  IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();

            var course = uow.Context.Set<Course>().Include(x=>x.Author).FirstOrDefault(x=>x.id==id);
              
            if (course == null) return NotFound();

            return View(course);
        }

        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
    
        public  IActionResult DeleteConfirmed(int id)
        {
            var course =  uow.Context.Set<Course>().Find(id);
            if (course != null)
            {
                uow.Repository<Course>().Delete(course);
            }

            uow.Complete();
            return RedirectToAction(nameof(Index));
        }

    }
}
