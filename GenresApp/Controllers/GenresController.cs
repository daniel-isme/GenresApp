using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GenresApp.Models;
using GenresApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GenresApp.Controllers
{
    public class GenresController : Controller
    {
        private readonly IGenresService genresService;

        public GenresController(IGenresService genresService)
        {
            this.genresService = genresService;
        }

        // GET: GenresController
        public ActionResult Index()
        {
            var genres = genresService.GetAllGenres().Where(g => !g.HasParent);

            return View(genres);
        }

        // GET: GenresController/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var genre = genresService.GetGenreById(id);
            if (genre == null)
            {
                return NotFound();
            }

            var genreViewModel = new GenreViewModel()
            {
                Id = genre.Id,
                Name = genre.Name,
                Description = genre.Description,
                SubGenres = genresService.GetAllSubGenresByGenreId(genre.Id)
            };

            return View(genreViewModel);
        }


        // GET: GenresController/Create
        public ActionResult Create(Guid? id)
        {
            if (id != null)
            {
                var genre = genresService.GetGenreById(id);
                if (genre == null)
                {
                    return NotFound();
                }

                var newGenre = new Genre() { ParentId = id };

                return View(newGenre);
            }

            return View();
        }

        // POST: GenresController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Genre genre)
        {
            if (ModelState.IsValid)
            {
                genre.Id = Guid.NewGuid();
                if (genre.HasParent)
                {
                    genresService.AddSubGenreToGenre(genre, genre.ParentId);
                }
                else
                {
                    genresService.AddGenre(genre);
                }
                return RedirectToAction(nameof(Index));
            }

            return View(genre);
        }
    }
}
