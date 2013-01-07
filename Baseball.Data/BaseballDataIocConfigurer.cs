using Baseball.Data.Repositories;
using Baseball.Lib.Repositories;
using IocContainer;

namespace Baseball.Data
{
    public static class BaseballDataIocConfigurer
    {
        public static void Configure()
        {
            Ioc.AddSingletonDefinition<IPlayersRepository, PlayersRepository>();
            Ioc.AddSingletonDefinition<IPlayerYearStatsRepository, PlayerYearStatsRepository>();
            Ioc.AddSingletonDefinition<ITeamRepository, TeamRepository>();
        }
    }
}
