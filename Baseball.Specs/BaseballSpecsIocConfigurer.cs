using Baseball.Lib;
using Baseball.Lib.Repositories;
using Baseball.Specs.Repositories;
using Baseball.Web;
using IocContainer;

namespace Baseball.Specs
{
    public static class BaseballSpecsIocConfigurer
    {
        public static void Configure()
        {
            BaseballWebIocConfigurer.Configure();
            BaseballLibIocConfigurer.Configure();
            Ioc.AddSingletonDefinition<IPlayersRepository, PlayersRepositoryStub>();
        }
    }
}