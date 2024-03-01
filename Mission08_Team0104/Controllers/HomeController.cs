using Microsoft.AspNetCore.Mvc;
using Mission08_Team0104.Models;
using System.Diagnostics;

namespace Mission08_Team0104.Controllers
{
    public class HomeController : Controller
    {
        private ITaskRepository _repo;
        public HomeController(ITaskRepository temp)
        {
            _repo = temp;
        }

        public IActionResult Index()
        {
            var display = _repo.Tasks
                .OrderBy(t => t.TaskId)
                .ToList();
            return View(display);
        }

        public IActionResult AddTask()
        {
            return View();
        }

        public IActionResult Delete()
        {
            return RedirectToAction("AddTask");
        }
        public IActionResult Edit()
        {
            return RedirectToAction("AddTask");
        }
    }
}
