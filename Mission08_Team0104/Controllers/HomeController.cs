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
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
