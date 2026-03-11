using Microblog.Core;
using Microblog.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace Microblog.Web.Controllers
{
    public class TweetsController : Controller
    {
        private SystemMikroblogowania system = AppState.System;

        public IActionResult Index()
        {
            return View(system);
        }

        [HttpPost]
        public IActionResult Like(int id)
        {
            system.PolubTweet(id);
            return RedirectToAction("Index");
        }
    }
}