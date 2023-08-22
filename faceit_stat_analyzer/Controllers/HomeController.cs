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
            List<GameViewModel> list = new List<GameViewModel>();
            for (int i = 0; i < 20; i++)
            {
                list.Add(new GameViewModel
                {
                    Date = new DateTime(2023, 8, 22),
                    Score = "16:0",
                    FirstHalfScore = "15:0",
                    SecondHalfScore = "1:0",
                    EloAfter = 3000,
                    EloGain = +25,
                    Map = "de_mirage",
                    Team = "team_--faro--",
                    Stats = "31-5-6",
                    Kd = 5.16,
                    Kr = 1.93,
                    Hs = 63,
                    HLTV = 2.31

                }); ;
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