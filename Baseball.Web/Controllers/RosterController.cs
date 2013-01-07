using Baseball.Lib.Managers;
using System.Web.Mvc;

namespace Baseball.Web.Controllers
{
    public class RosterController : Controller
    {
        public RosterManager RosterManager { get; set; }

        public RosterController(RosterManager rosterManager)
        {
            RosterManager = rosterManager;
        }

        public ActionResult Index()
        {
            var players = RosterManager.GetAllPlayers();
            return View(players);
        }

        public ActionResult Details(int id)
        {
            var player = RosterManager.GetPlayerById(id);

            if (player == null)
                return HttpNotFound();

            return View(player);
        }
    }
}
