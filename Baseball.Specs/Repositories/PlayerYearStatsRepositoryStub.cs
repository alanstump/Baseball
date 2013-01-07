using System.Collections.Generic;
using System.Linq;
using Baseball.Lib.Models;
using Baseball.Lib.Repositories;

namespace Baseball.Specs.Repositories
{
    public class PlayerYearStatsRepositoryStub : IPlayerYearStatsRepository
    {
        public List<PlayerYearStats> PlayerYearStats { get; set; }

        public PlayerYearStatsRepositoryStub()
        {
            PlayerYearStats = new List<PlayerYearStats>();   
        }

        public IList<PlayerYearStats> GetAllForYear(int year)
        {
            return PlayerYearStats.Where(x => x.Year == year).ToList();
        }
    }
}