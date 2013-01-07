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
            Teams = new List<Team>();    
        }

        public IList<Team> GetAll()
        {
            return Teams;
        }
    }
}