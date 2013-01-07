using Baseball.Lib.Models;
using System.Collections.Generic;

namespace Baseball.Lib.Repositories
{
    public interface IPlayersRepository
    {
        IList<Player> GetAll();
        Player GetById(int id);
    }
}
