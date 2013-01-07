using System.Collections.Generic;
using Baseball.Lib.Models;

namespace Baseball.Lib.Repositories
{
    public interface ITeamRepository
    {
        IList<Team> GetAll();
    }
}