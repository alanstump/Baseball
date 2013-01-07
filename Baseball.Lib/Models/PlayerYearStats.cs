namespace Baseball.Lib.Models
{
    public class PlayerYearStats
    {
        public int PlayerId { get; set; }
        public int Year { get; set; }
        public int GamesPlayed { get; set; }
        public int AtBats { get; set; }
        public int Runs { get; set; }
        public int Hits { get; set; }
        public int Doubles { get; set; }
        public int Triples { get; set; }
        public int HomeRuns { get; set; }
        public int RunsBattedIn { get; set; }
        public int Walks { get; set; }
        public int StrikeOuts { get; set; }
        public decimal Average { get; set; }
        public decimal OnBasePercantage { get; set; }
    }
}