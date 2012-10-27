using Baseball.Lib.Models;
using System.Collections.Generic;

namespace Baseball.Lib.Repositories
{
    public interface IPlayersRepository
    {
        IEnumerable<Player> GetAll();
        Player GetById(int id);
    }
}
