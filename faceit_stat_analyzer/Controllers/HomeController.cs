using faceit_stat_analyzer.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace faceit_stat_analyzer.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult TestPage()
        {
            List<TestViewModel> list = new List<TestViewModel>();
            for (int i = 0; i < 10; i++)
            {
                list.Add(new TestViewModel
                {
                    Name = "Name " + i,
                    Description = "Description " + i
                });
            }

            return View(list);
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