using Baseball.Lib.Models;
using Baseball.Lib.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Baseball.Data.Repositories
{
    public class PlayersRepository : IPlayersRepository
    {
        public List<Player> Players { get; set; }

        public PlayersRepository()
        {
            Players = new List<Player>
            {
                new Player
                    {
                        FirstName = "Alan",
                        LastName = "Stump",
                        Id = 1,
                        Number = 9
                    }
            };
        }

        public IEnumerable<Player> GetAll()
        {
            return Players;
        }

        public Player GetById(int id)
        {
            return Players.FirstOrDefault(x => x.Id == id);
        }
    }
}
