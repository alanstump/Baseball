using System.Collections.Generic;
using Baseball.Lib.Repositories;

namespace Baseball.Specs.Repositories
{
    public class TeamRepositoryStub : ITeamRepository
    {
        public List<Lib.Models.Team> Teams { get; set; }

        public TeamRepositoryStub()
        {
            Teams = new List<Lib.Models.Team>();    
        }

        public IList<Lib.Models.Team> GetAll()
        {
            return Teams;
        }
    }
}