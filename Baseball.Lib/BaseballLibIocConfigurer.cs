using Baseball.Lib.Managers;
using IocContainer;

namespace Baseball.Lib
{
    public static class BaseballLibIocConfigurer
    {
        public static void Configure()
        {
            Ioc.AddSingletonDefinition<RosterManager>();
        }
    }
}
