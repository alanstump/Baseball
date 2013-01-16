using System.Collections.Generic;
using Baseball.Lib.Models;
using TechTalk.SpecFlow;

namespace Baseball.Specs.Helpers
{
    public class PlayerYearStatsHelper
    {
        public static IEnumerable<PlayerYearStats> CreateFrom(Table table)
        {
            var playerYearStats = new List<PlayerYearStats>();

            foreach (var row in table.Rows)
            {
                var playerYearStat = new PlayerYearStats {Player = new Player()};

                if (row.ContainsKey("LastName"))
                    playerYearStat.Player.LastName = row["LastName"];

                if (row.ContainsKey("Year"))
                    playerYearStat.Year = int.Parse(row["Year"]);

                if (row.ContainsKey("ABs"))
                    playerYearStat.AtBats = int.Parse(row["ABs"]);

                if (row.ContainsKey("Runs"))
                    playerYearStat.Runs = int.Parse(row["Runs"]);

                if (row.ContainsKey("Hits"))
                    playerYearStat.Hits = int.Parse(row["Hits"]);

                if (row.ContainsKey("Doubles"))
                    playerYearStat.Doubles = int.Parse(row["Doubles"]);

                if (row.ContainsKey("Triples"))
                    playerYearStat.Triples = int.Parse(row["Triples"]);

                if (row.ContainsKey("HomeRuns"))
                    playerYearStat.HomeRuns = int.Parse(row["HomeRuns"]);

                if (row.ContainsKey("RBIs"))
                    playerYearStat.RunsBattedIn = int.Parse(row["RBIs"]);

                if (row.ContainsKey("Walks"))
                    playerYearStat.Walks = int.Parse(row["Walks"]);

                if (row.ContainsKey("StrikeOuts"))
                    playerYearStat.StrikeOuts = int.Parse(row["StrikeOuts"]);

                playerYearStats.Add(playerYearStat);
            }

            return playerYearStats;
        } 
    }
}