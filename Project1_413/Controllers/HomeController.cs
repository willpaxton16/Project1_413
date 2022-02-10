using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Project1_413.Models;
//using Project1_413.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Project1_413.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private TaskContext _yeetContext { get; set; }

        public HomeController(ILogger<HomeController> logger, TaskContext yeet)
        {
            _logger = logger;
            _yeetContext = yeet;
        }

        public IActionResult Index()
        {
            var tasks = _yeetContext.TaskResponses.Include(x => x.Category).Where(x => x.Completed == false).ToList();
            return View(tasks);
        }

        [HttpGet]
        public IActionResult CreateTask()
        {
            ViewBag.Categories = _yeetContext.Categories.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult CreateTask(TaskResponse tr)
        {
            _yeetContext.Add(tr);
            _yeetContext.SaveChanges();
            var tasks = _yeetContext.TaskResponses.Include(x => x.Category).Where(x => x.Completed == false).ToList();
            return View("Index", tasks);
        }

        //[HttpGet]
        //public IActionResult DisplayTasks()
        //{
        //    var tasks = _yeetContext.TaskResponses.Include(x => x.Category).Where(x => x.Completed == false).ToList();
        //    return View(tasks);
        //}

        [HttpGet]
        public IActionResult Edit(string id)
        {
            ViewBag.Categories = _yeetContext.Categories.ToList();
            var taskEntry = _yeetContext.TaskResponses.Single(x => x.Task == id);
            return View("createTask", taskEntry);
        }

        [HttpPost]
        public IActionResult Edit(TaskResponse tr)
        {
            _yeetContext.Update(tr);
            _yeetContext.SaveChanges();

            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Delete(string id)
        {
            var movie = _yeetContext.TaskResponses.Single(x => x.Task == id);
            return View(movie);
        }
        [HttpPost]
        public IActionResult Delete(TaskResponse tr)
        {
            _yeetContext.TaskResponses.Remove(tr);
            _yeetContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
