using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GenresApp.Controllers
{
    public class GenresController : Controller
    {
        // GET: GenresController
        public ActionResult Index()
        {
            return View();
        }

        // GET: GenresController/Details/5
        public ActionResult Details(Guid id)
        {
            return View();
        }

        // GET: GenresController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GenresController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
