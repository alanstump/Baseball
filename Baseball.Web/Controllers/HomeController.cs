using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Baseball.Web.Controllers
{
    public class HomeController : Controller
    {
        public B _b { get; set; }
        public HomeController(B b)
        {
            _b = b;
        }
        // GET: /Home/
        public ActionResult Index()
        {
            return View();
        }
    }

    public class B { }
}
