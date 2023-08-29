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
        public double Kd;
        public double Kr;
        public int Hs;
        public double HLTV;
    }
}


//public class basemodel
//{
//    public playerinfomodel playerinfo
//        public List<GameViewModel> matches
//}