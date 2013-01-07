using System.Collections.Generic;
using System.Linq;
using Baseball.Lib.Models;
using Baseball.Lib.Repositories;

namespace Baseball.Specs.Repositories
{
    public class PlayersRepositoryStub : IPlayersRepository
    {
        public List<Player> Players { get; set; }

        public PlayersRepositoryStub()
        {
            Players = new List<Player>();
        }

        public IList<Player> GetAll()
        {
            return Players;
        }

        public Player GetById(int id)
        {
            return Players.FirstOrDefault(x => x.Id == id);
        }
    }
}