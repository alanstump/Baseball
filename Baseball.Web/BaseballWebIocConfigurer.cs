using Baseball.Web.Controllers;
using IocContainer;

namespace Baseball.Web
{
    public static class BaseballWebIocConfigurer
    {
        public static void Configure()
        {
            Ioc.AddPrototypeDefinition<HomeController>();
            Ioc.AddPrototypeDefinition<RosterController>();
            Ioc.AddPrototypeDefinition<TeamController>();
        }
    }
}