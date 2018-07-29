using MoviesDownload.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MoviesDownload.Controllers
{
    public class ProducerController : Controller
    {
        [HttpGet]
        public ActionResult AddProducer()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddProducer(Producers objProducer)
        {
            IMDB_Context context = new IMDB_Context();
            var num = context.Actors.Where(x => x.Name == objProducer.Name && x.Sex == objProducer.Sex).ToList<Actors>().Count;
            if (num > 0)
            {
                ModelState.AddModelError("", "Producer Already Exist");
                return View();
            }
            context.Producers.Add(objProducer);
            context.SaveChanges();
            return RedirectToAction("GetMovies", "Imdb", null);
        }
    }
}