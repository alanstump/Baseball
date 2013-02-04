using System.Collections.Generic;
using Baseball.Lib.Models;
using Baseball.Lib.Repositories;

namespace Baseball.Data.Repositories
{
    public class TeamRepository : ITeamRepository
    {
        public List<Team> Teams { get; set; }

        public TeamRepository()
        {
            Teams = new List<Team>
            {
                new Team
                {
                    Year = 2012,
                    Wins = 23,
                    Losses = 11,
                    CurrentSeason = false
                },
                new Team
                {
                    Year = 2013,
                    Wins = 5,
                    Losses = 1,
                    CurrentSeason = true
                }
            };
        }

        public IList<Team> GetAll()
        {
            return Teams;
        }
    }
}