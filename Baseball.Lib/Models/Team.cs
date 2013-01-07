namespace Baseball.Lib.Models
{
    public class Team
    {
        public int Year { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public bool CurrentSeason { get; set; }
    }
}