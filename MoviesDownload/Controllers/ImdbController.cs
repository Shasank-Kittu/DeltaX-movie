using MoviesDownload.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MoviesDownload.Controllers
{
    public class ImdbController : Controller
    {
       public ActionResult GetMovies()
        {
            IMDB_Context context = new IMDB_Context();
            var _movieslist = context.Movies.ToList<Movies>();
            return View(_movieslist);
        }
        public ActionResult GetmovieDetails(int id)
        {
            IMDB_Context context = new IMDB_Context();
           Movies mov= context.Movies.Where(x => x.MovieId == id).FirstOrDefault();
            return PartialView(mov);
        }
    }
}