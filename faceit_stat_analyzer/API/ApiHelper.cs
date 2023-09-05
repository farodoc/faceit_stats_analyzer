using faceit_stat_analyzer.API.Models;
using Newtonsoft.Json;
using RestSharp;

namespace faceit_stat_analyzer.API
{
    public class ApiHelper
    {
        private string gameId = "csgo";
        private string API_KEY = "a5092d75-cf4d-4f4b-a30b-7bb6c58259c1";

        public PlayerInfo GetPlayerInfo(string nick)
        {
            RestClient client = new RestClient($"https://open.faceit.com/data/v4/players?nickname={nick}");
            var request = new RestRequest();
            request.AddHeader("accept", "application/json");
            request.AddHeader("Authorization", "Bearer " + API_KEY);

            var response = client.Execute(request);
            var deserialized = JsonConvert.DeserializeObject<PlayerInfo>(response.Content);

            return deserialized;
        }

        public List<MatchInfo> GetPlayerMatches(string playerId)
        {
            RestClient client = new RestClient($"https://open.faceit.com/data/v4/players/{playerId}/history?game={gameId}&offset=0&limit=20");
            var request = new RestRequest();
            request.AddHeader("accept", "application/json");
            request.AddHeader("Authorization", "Bearer " + API_KEY);

            var response = client.Execute(request);
            var deserialized = JsonConvert.DeserializeObject<MatchSearchResult>(response.Content);

            return deserialized.items.ToList();
        }

        public SingleMatchDetails GetSingleMatchDetails(string matchId)
        {
            RestClient client = new RestClient($"https://open.faceit.com/data/v4/matches/{matchId}");
            var request = new RestRequest();
            request.AddHeader("accept", "application/json");
            request.AddHeader("Authorization", "Bearer " + API_KEY);

            var response = client.Execute(request);
            var deserialized = JsonConvert.DeserializeObject<SingleMatchDetails>(response.Content);

            return deserialized;
        }

        public SingleMatchStats GetSingleMatchStats(string matchId)
        {
            RestClient client = new RestClient($"https://open.faceit.com/data/v4/matches/{matchId}/stats");
            var request = new RestRequest();
            request.AddHeader("accept", "application/json");
            request.AddHeader("Authorization", "Bearer " + API_KEY);

            var response = client.Execute(request);
            var deserialized = JsonConvert.DeserializeObject<SingleMatchStats>(response.Content);

            return deserialized;
        }
    }
}
