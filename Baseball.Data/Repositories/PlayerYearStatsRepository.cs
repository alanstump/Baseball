using System.Collections.Generic;
using System.Linq;
using Baseball.Lib.Models;
using Baseball.Lib.Repositories;

namespace Baseball.Data.Repositories
{
    public class PlayerYearStatsRepository : IPlayerYearStatsRepository
    {
        public List<PlayerYearStats> PlayerYearStats { get; set; }

        public PlayerYearStatsRepository()
        {
            PlayerYearStats = new List<PlayerYearStats>
            {
                new PlayerYearStats
                {
                    Player = GetPlayer(),
                    Year = 2013,
                    GamesPlayed = 6,
                    AtBats = 40,
                    Runs = 15,
                    Hits = 25,
                    Doubles = 7,
                    Triples = 5,
                    HomeRuns = 3,
                    RunsBattedIn = 36,
                    StrikeOuts = 3,
                    Walks = 2,
                },
                new PlayerYearStats
                {
                    Player = GetPlayer(),
                    Year = 2012,
                    GamesPlayed = 34,
                    AtBats = 100,
                    Runs = 50,
                    Hits = 60,
                    Doubles = 12,
                    Triples = 8,
                    HomeRuns = 10,
                    RunsBattedIn = 78,
                    StrikeOuts = 6,
                    Walks = 10,
                }
            };
        }

        static Player GetPlayer()
        {
            return new Player
            {
                FirstName = "Alan",
                LastName = "Stump",
                Id = 1,
                Number = 9
            };
        }

        public IList<PlayerYearStats> GetAllForYear(int year)
        {
            return PlayerYearStats.Where(x => x.Year == year).ToList();
        }
    }
}