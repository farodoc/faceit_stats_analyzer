using faceit_stat_analyzer.API;
using faceit_stat_analyzer.API.Models;
using faceit_stat_analyzer.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Globalization;

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
            return RedirectToAction("Matches");
        }

        public IActionResult Dupa()
        {
            ApiHelper help = new ApiHelper();
            PlayerInfo res = help.GetPlayerInfo("--faro--");

            return View();
        }

        public IActionResult Matches()
        {
            var list = new List<MatchViewModel>();
            for (int i = 0; i < 20; i++)
            {
                list.Add(new MatchViewModel
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
                    Kd = "5.16",
                    Kr = "1.93",
                    Hs = "63",
                    HLTV = 2.31

                });
            }

            MatchesPageViewModel matchesPageViewModel = new MatchesPageViewModel();

            ApiHelper helper = new ApiHelper();
            PlayerInfo playerInfoResponse = helper.GetPlayerInfo("--faro--");
            PlayerInfoViewModel playerInfo = new PlayerInfoViewModel();
            playerInfo.Nick = playerInfoResponse.nickname;
            playerInfo.Avatar = playerInfoResponse.avatar;
            matchesPageViewModel.PlayerInfo = playerInfo;

            List<MatchInfo> playerMatchesResponse = helper.GetPlayerMatches(playerInfoResponse.player_id);
            matchesPageViewModel.Matches = new List<MatchViewModel>();


            foreach (var match in playerMatchesResponse.Take(3))
            {
                var matchDetails = helper.GetSingleMatchDetails(match.match_id);
                var matchStats = helper.GetSingleMatchStats(match.match_id);
                var myTeam = matchStats.rounds[0].teams.Where(x => x.players.Any(p => p.player_id == playerInfoResponse.player_id)).First();
                var me = myTeam.players.First(x => x.player_id == playerInfoResponse.player_id);

                matchesPageViewModel.Matches.Add(
                    new MatchViewModel
                    {
                        Team = myTeam.team_stats.Team,
                        Map = matchDetails.voting.map.pick[0],
                        Date = DateTimeOffset.FromUnixTimeSeconds(matchDetails.configured_at).LocalDateTime,
                        Score = matchStats.rounds[0].round_stats.Score,
                        Kd = me.player_stats.KDRatio,
                        Kr = me.player_stats.KRRatio,
                        Hs = (int.Parse(me.player_stats.Headshots) * 100 / (double)int.Parse(me.player_stats.Kills)).ToString().Substring(0, 2),
                        Kills = me.player_stats.Kills,
                        Deaths = me.player_stats.Deaths,
                        Assists = me.player_stats.Assists
                    });
            }

            matchesPageViewModel.Matches.AddRange(list);
            return View(matchesPageViewModel);
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