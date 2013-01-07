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
            PlayerYearStats = new List<PlayerYearStats>();   
        }

        public IList<PlayerYearStats> GetAllForYear(int year)
        {
            return PlayerYearStats.Where(x => x.Year == year).ToList();
        }
    }
}