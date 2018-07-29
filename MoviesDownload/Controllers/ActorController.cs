using MoviesDownload.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MoviesDownload.Controllers
{
    public class ActorController : Controller
    {
        [HttpGet]
        public ActionResult AddActor()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddActor(Actors objActor)
        {
            IMDB_Context context = new IMDB_Context();
            var num = context.Actors.Where(x => x.Name == objActor.Name && x.Sex == objActor.Sex).ToList<Actors>().Count;
            if(num>0)
            {
                ModelState.AddModelError("", "Actor Already Exist");
                return View();
            }
            context.Actors.Add(objActor);
            context.SaveChanges();
            return RedirectToAction("GetMovies", "Imdb", null);
        }
    }
}