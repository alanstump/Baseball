using System;
using System.Collections.Generic;
using Baseball.Lib.Utils;

namespace Baseball.Lib.Models
{
    public class TeamStats
    {
        public int Year { get; private set; }
        public int Wins { get; private set; }
        public int Losses { get; private set; }
        public IEnumerable<int> Seasons { get; private set; }
        public IEnumerable<PlayerYearStats> PlayerYearStats { get; private set; }
        public int TotalAtBats { get; private set; }
        public int TotalRuns { get; private set; }
        public int TotalHits { get; private set; }
        public int TotalDoubles { get; private set; }
        public int TotalTriples { get; private set; }
        public int TotalHomeRuns { get; private set; }
        public int TotalRunsBattedIn { get; private set; }
        public int TotalWalks { get; private set; }
        public int TotalStrikeOuts { get; private set; }
        
        public double TotalAverage
        {
            get { return PercentHelper.CalculateAverage(TotalAtBats, TotalHits); }
        }

        public double TotalOnBasePercentage
        {
            get { return PercentHelper.CalculateOnBasePercentage(TotalAtBats, TotalHits, TotalWalks); }
        }

        public TeamStats()
        {
            Year = DateTime.Now.Year;
            Seasons = new List<int> { Year };
            PlayerYearStats = new List<PlayerYearStats>();
        }

        public TeamStats(Team team, IEnumerable<PlayerYearStats> playerYearStats, IEnumerable<int> seasons)
        {
            Year = team.Year;
            Wins = team.Wins;
            Losses = team.Losses;
            Seasons = seasons;
            PlayerYearStats = playerYearStats;

            AddTotals();
        }

        void AddTotals()
        {
            foreach (var pys in PlayerYearStats)
            {
                TotalAtBats += pys.AtBats;
                TotalRuns += pys.Runs;
                TotalHits += pys.Hits;
                TotalDoubles += pys.Doubles;
                TotalTriples += pys.Triples;
                TotalHomeRuns += pys.HomeRuns;
                TotalRunsBattedIn += pys.RunsBattedIn;
                TotalWalks += pys.Walks;
                TotalStrikeOuts += pys.StrikeOuts;
            }
        }
    }
}