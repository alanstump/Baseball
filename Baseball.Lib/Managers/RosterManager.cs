using Baseball.Lib.Models;
using Baseball.Lib.Repositories;
using System.Collections.Generic;

namespace Baseball.Lib.Managers
{
    public class RosterManager
    {
        public IPlayersRepository PlayersRepository { get; set; }

        public RosterManager(IPlayersRepository playersRepository)
        {
            PlayersRepository = playersRepository;
        }

        public virtual IEnumerable<Player> GetAllPlayers()
        {
            return PlayersRepository.GetAll();
        }

        public virtual Player GetPlayerById(int id)
        {
            return PlayersRepository.GetById(id);
        }
    }
}
