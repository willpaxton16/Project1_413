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
            return View();
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
            return View("DisplayTasks");
        }

        [HttpGet]
        public IActionResult DisplayTasks()
        {
            var tasks = _yeetContext.TaskResponses.Include(x => x.Category).Where(x => x.Completed == false).ToList();
            return View(tasks);
        }
    }
}
