using MoviesDownload.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Mvc;

namespace MoviesDownload.Controllers
{
    public class MovieController : Controller
    {
        // GET: Movie
        public ActionResult AddMovie()
        {
            IMDB_Context context = new IMDB_Context();
            var actorslist = context.Actors.Select(x => new SelectListItem
            {
                Value = x.ActorId.ToString(),
                Text = x.Name
            }).ToList();
            var producerlist = context.Producers.Select(x => new SelectListItem
            {
                Value = x.ProducerId.ToString(),
                Text = x.Name
            }).ToList();

            MovieModel model = new MovieModel()
            {
                Actors = actorslist,
                Producers=producerlist
            };
            return View("AddMovie",model);
        }
        [HttpPost]
        public ActionResult AddMovie(MovieModel objMovie)
        {
            IMDB_Context context = new IMDB_Context();
            Movies movie = ConvertMovieModelToMovies(objMovie);
            context.Movies.Add(movie);
            context.SaveChanges();
            return RedirectToAction("GetMovies", "Imdb", null);
        }

        [HttpGet]
        public ActionResult EditMovie(int id)
        {
            IMDB_Context context = new IMDB_Context();
            Movies movie = context.Movies.Where(m => m.MovieId == id).SingleOrDefault<Movies>();
            Producers prod=context.Producers.Where(p => p.ProducerId == movie.ProducerId).SingleOrDefault();
            movie.Producer = prod;
            var _ProducerList = context.Producers.Where(x=>x.ProducerId!=prod.ProducerId).ToList<Producers>();
            var _ActorsList = context.Actors.ToList<Actors>();

            var _SelectListOfProducers= new List<SelectListItem>()
                {
                    new SelectListItem(){ Text=prod.Name,Value=prod.ProducerId.ToString(),Selected=true}
                };
            var _SelectedListOfActors = new List<SelectListItem>();
            foreach (var item in _ProducerList)
            {
                _SelectListOfProducers.Add(new SelectListItem()
                {
                    Text = item.Name,
                    Value = item.ProducerId.ToString()
                });
            };
            foreach (var item in _ActorsList)
            {
                _SelectedListOfActors.Add(new SelectListItem()
                {
                    Text = item.Name,
                    Value = item.ActorId.ToString()
                });
            };
            MovieModel model = new MovieModel()
            {
                Name = movie.Name,
                Yearofrelease = movie.Yearofrelease.ToShortDateString(),
                Plot = movie.Plot,
                Poster = movie.Poster,
                Producers =_SelectListOfProducers,
                Actors= _SelectedListOfActors
            };
            return View(model);
        }
        [HttpPost]
        public ActionResult EditMovie(MovieModel objMovie)
        {
            IMDB_Context context = new IMDB_Context();
            Movies movie = ConvertMovieModelToMovies(objMovie);
            context.Movies.Add(movie);
            context.SaveChanges();
            return RedirectToAction("GetMovies", "Imdb", null);
        }
        [NonAction]
        private Movies ConvertMovieModelToMovies(MovieModel objMovie)
        {
            Movies movie = null;
            using (IMDB_Context context = new IMDB_Context())
            {
                Producers objProducer = context.Producers.Where(x => x.ProducerId == objMovie.ProducerId).SingleOrDefault<Producers>();
                List<Actors> _ActorsList = new List<Actors>();
                foreach (var item in objMovie.ActorsId)
                    _ActorsList.Add(context.Actors.Where(x => x.ActorId == item).SingleOrDefault());
                 movie = new Movies()
                {
                    Name = objMovie.Name,
                    Plot = objMovie.Plot,
                    Yearofrelease = Convert.ToDateTime(objMovie.Yearofrelease),
                    Producer = objProducer,
                    Actors = _ActorsList
                };
            }
            return movie;
        }
    }
}