using System.Web.Mvc;
using Baseball.Lib.Managers;

namespace Baseball.Web.Controllers
{
    public class TeamStatsController : Controller
    {
        public TeamManager TeamManager { get; set; }

        public TeamStatsController(TeamManager teamManager)
        {
            TeamManager = teamManager;
        }

        public ActionResult Index(int? season = null)
        {
            var teamStats = season.HasValue ? 
                                TeamManager.GetSeasonStatsFor(season.Value) : 
                                TeamManager.GetCurrentSeasonStats();

            return View(teamStats);
        }
    }
}
