using Microsoft.AspNetCore.Mvc;
using Microblog.Core;
using Microblog.Web.Services;

namespace Microblog.Web.Controllers
{
    public class UsersController : Controller
    {
        private SystemMikroblogowania system = AppState.System;

        public IActionResult Index()
        {
            return View(system);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(string nazwaUzytkownika, string email)
        {
            system.ZarejestrujUzytkownika(nazwaUzytkownika, email);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Follow(int id)
        {
            Uzytkownik znaleziony = null;

            for (int i = 0; i < system.LiczbaUzytkownikow; i++)
            {
                if (system.Uzytkownicy[i].Id == id)
                {
                    var tymczasowy = new Uzytkownik();
                    tymczasowy.Obserwuj(system.Uzytkownicy[i]);

                    znaleziony = system.Uzytkownicy[i];
                    break;
                }
            }

            if (znaleziony == null)
                return NotFound();

            return View("Details", znaleziony);
        }
        public IActionResult Details(int id)
        {
            var system = AppState.System;

            Uzytkownik user = null;

            for (int i = 0; i < system.LiczbaUzytkownikow; i++)
            {
                if (system.Uzytkownicy[i].Id == id)
                {
                    user = system.Uzytkownicy[i];
                    break;
                }
            }

            if (user == null)
                return NotFound();

            return View(user);
        }
    }
}