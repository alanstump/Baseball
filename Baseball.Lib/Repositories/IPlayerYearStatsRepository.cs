using System.Collections.Generic;
using Baseball.Lib.Models;

namespace Baseball.Lib.Repositories
{
    public interface IPlayerYearStatsRepository
    {
        IList<PlayerYearStats> GetAllForYear(int year);
    }
}