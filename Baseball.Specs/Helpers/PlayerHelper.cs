using System.Collections.Generic;
using Baseball.Lib.Models;
using TechTalk.SpecFlow;

namespace Baseball.Specs.Helpers
{
    public static class PlayerHelper
    {
        public static IEnumerable<Player> CreateFrom(Table table)
        {
            var players = new List<Player>();

            foreach (var row in table.Rows)
            {
                var player = new Player();

                if (row.ContainsKey("FirstName"))
                    player.FirstName = row["FirstName"];

                if (row.ContainsKey("LastName"))
                    player.LastName = row["LastName"];

                if (row.ContainsKey("Id"))
                    player.Id = int.Parse(row["Id"]);

                if (row.ContainsKey("Number"))
                    player.Number = int.Parse(row["Number"]);

                players.Add(player);
            }

            return players;
        }
    }
}