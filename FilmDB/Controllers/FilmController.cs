using FilmDB.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmDB.Controllers
{
    public class FilmController : Controller
    {
        private readonly IFilmManager filmManager;

        public FilmController(IFilmManager filmManager)
        {
            this.filmManager = filmManager;
        }

        public IActionResult Index()
        {
            var model = filmManager.GetFilms();
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FilmModel film)
        {
            if (ModelState.IsValid)
            {
                filmManager.AddFilm(film);
                return RedirectToAction("Details", new { id = film.Id });
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = filmManager.GetFilm(id);
            if (model == null)
            {
                return View("NotFound");
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FilmModel film)
        {
            if (ModelState.IsValid)
            {
                filmManager.UpdateFilm(film);
                TempData["Message"] = "Film info updated!";
                return RedirectToAction("Details", new { id = film.Id });
            }
            return View(film);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var model = filmManager.GetFilm(id);
            if (model == null)
            {
                return View("NotFound");
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var model = filmManager.GetFilm(id);
            if (model == null)
            {
                return View("NotFound");
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection form)
        {
            filmManager.RemoveFilm(id);
            return RedirectToAction("Index");
        }
    


}
}
