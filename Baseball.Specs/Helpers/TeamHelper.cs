using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace Baseball.Specs.Helpers
{
    public static class TeamHelper
    {
        public static IEnumerable<Lib.Models.Team> CreateFrom(Table table)
        {
            var teams = new List<Lib.Models.Team>();

            foreach (var row in table.Rows)
            {
                var team = new Lib.Models.Team();

                if (row.ContainsKey("Year"))
                    team.Year = int.Parse(row["Year"]);

                if (row.ContainsKey("Wins"))
                    team.Wins = int.Parse(row["Wins"]);

                if (row.ContainsKey("Losses"))
                    team.Losses = int.Parse(row["Losses"]);

                if (row.ContainsKey("CurrentSeason"))
                    team.CurrentSeason = bool.Parse(row["CurrentSeason"]);

                teams.Add(team);
            }

            return teams;
        }
    }
}