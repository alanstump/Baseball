using System.Web.Mvc;
using Baseball.Lib.Managers;

namespace Baseball.Web.Controllers
{
    public class TeamController : Controller
    {
        public TeamManager TeamManager { get; set; }

        public TeamController(TeamManager teamManager)
        {
            TeamManager = teamManager;
        }

        public ActionResult Index()
        {
            var teamStats = TeamManager.GetCurrentSeasonStats();
            return View(teamStats);
        }
    }
}
