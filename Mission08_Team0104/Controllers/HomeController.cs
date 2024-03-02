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

        [HttpGet]
        public IActionResult Index()
        {
            var allTasks = _repo.GetAllTasks();
            return View(allTasks);
        }

        [HttpGet]
        public IActionResult AddTask()
        {
            ViewBag.Categories = _repo.Categories
                .OrderBy(x => x.CategoryId)
                .ToList();

            return View("AddTask", new Models.Task());
        }

        [HttpPost]
        public IActionResult AddTask(Models.Task newTask)
        {
            if(ModelState.IsValid)
            {
                _repo.AddTask(newTask);

                return View("Confirmation");

            }
            else
            //invalid - return the form with the data the user entered
            {
                ViewBag.Categories = _repo.Categories.OrderBy(x => x.CategoryName).ToList();
                return View(newTask);
            }

            // return View(new Models.Task());
        }

        [HttpGet]
        public IActionResult Edit(int id )
        {
            var taskToEdit = _repo.Tasks
                .Single(t => t.TaskId == id);
            ViewBag.Categories = _repo.Categories
                .OrderBy(x => x.CategoryId)
                .ToList();
                
            return View("AddTask", taskToEdit);
        }

        [HttpPost]
        public IActionResult Edit(Models.Task updatedTask)
        {
            if (ModelState.IsValid)
            {
                _repo.UpdateTask(updatedTask);
                return RedirectToAction("index");
            }
            else
            //invalid - return the form with the data the user entered

            {
                ViewBag.Categories = _repo.Categories
                    .OrderBy(x => x.CategoryId)
                    .ToList();
                return View("AddTask", updatedTask);
            }   
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            var taskToDelete = _repo.Tasks
                .Single(x => x.TaskId == id);
            return View(taskToDelete);
        }

        [HttpPost]
        public IActionResult Delete(Models.Task taskToDelete)
        {
            _repo.RemoveTask(taskToDelete);

            return RedirectToAction("index");
        }
    }
}
