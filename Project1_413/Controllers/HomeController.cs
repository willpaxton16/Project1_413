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
        private taskContext _yeetContext { get; set; }

        public HomeController(ILogger<HomeController> logger, taskContext yeet)
        {
            _logger = logger;
            _yeetContext = yeet;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult createTask()
        {
            ViewBag.Categories = _yeetContext.Categories.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult createTask(taskResponse tr)
        {
            _yeetContext.Add(tr);
            _yeetContext.SaveChanges();
            return View("displayTasks");
        }

        [HttpGet]
        public IActionResult displayTasks()
        {
            var tasks = _yeetContext.taskResponses.Include(x => x.Category).Where(x => x.completed == false).ToList();
            return View(tasks);
        }
    }
}
