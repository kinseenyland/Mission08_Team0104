using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            ViewBag.Categories = _repo.Categories
                .OrderBy(x => x.CategoryId)
                .ToList();


            return View(new Models.Task());
        }

        [HttpPost]
        public IActionResult AddTask(Models.Task addTask)
        {
            if(ModelState.IsValid)
            {
                _repo.AddTask(addTask);

            }

            return View(new Models.Task());
        }

     
        public IActionResult Edit(int id )
        {
            var updateTask = _repo.Tasks
                .Single(t => t.TaskId == id);
            ViewBag.Categories = _repo.Tasks
                .OrderBy(x => x.CategoryId)
                .ToList();
                
            return RedirectToAction("AddTask", updateTask);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var deleteRecord = _repo.Tasks
                .Single(x => x.TaskId == id);
            _repo.Tasks.Remove(deleteRecord);
            return View("index");
        }

        
        public IActionResult Delete(Models.Task deleteTask)
        {
            _repo.Tasks.Remove(deleteTask);

            return RedirectToAction("DisplayCollection");
        }
    }
}
