using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Foosball.Controllers
{
    public class MatchController : Controller
    {
        // GET: Match
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult CreateMatch()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateMatch()
        {
            // if player in p1 - p4 (player.active = true) -> Continue
        }
    }
}