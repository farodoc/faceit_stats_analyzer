using System.Drawing;

namespace faceit_stat_analyzer.Models
{
    public class MatchViewModel
    {
        public DateTime Date;
        public string Score;
        public string FirstHalfScore;
        public string SecondHalfScore;
        public int EloAfter;
        public int EloGain;
        public string Map;
        public string Team;
        public string Stats;
        public string Kd;
        public string Kr;
        public string Hs;
        public double HLTV;
        public string Kills;
        public string Deaths;
        public string Assists;
    }
}