using MoviesDownload.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MoviesDownload.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Create()
        {

                return View();
        }
        public ActionResult Index()
        {
            using (IMDB_Context context = new IMDB_Context())
            {
                var movies = new List<Movies>() {
                        new Movies(){Name="Movie 3",Plot="122",Yearofrelease=DateTime.Now,Producer=new Producers(){Name="p1",Sex=
                        "male" } },
                         new Movies(){Name="Movie 4",Plot="2",Yearofrelease=DateTime.Now,Producer=new Producers(){Name="p1",Sex=
                        "male" } }
                } ;
                foreach(var item in movies)
                     context.Movies.Add(item);
                context.Actors.Add(new Actors()
                {
                    Bio = "sdfasdfasdf",
                    DOB = DateTime.Now,
                    Name = "Actor 2",
                    Sex = "Male",
                    Movies = movies

                });
                context.Actors.Add(new Actors()
                {
                    Bio = "sdfasdfafdadfasdf",
                    DOB = DateTime.Now,
                    Name = "Actor 3",
                    Sex = "Male",
                    Movies=movies
                });
                var movies2 = new List<Movies>() {
                        new Movies(){Name="Movie 1",Plot="122",Yearofrelease=DateTime.Now,Producer=new Producers(){Name="p1",Sex="male" } },
                         new Movies(){Name="Movie 2",Plot="2",Yearofrelease=DateTime.Now,Producer=new Producers(){Name="p1",Sex="male" } }
                    };
                foreach (var item in movies2)
                    context.Movies.Add(item);
                context.Actors.Add(new Actors()
                {
                    Bio = "sdfasdfasdf",
                    DOB = DateTime.Now,
                    Name = "Actor 4",
                    Sex = "Male",
                    Movies = movies2
                });
                //    context.SaveChanges();
                //}
                context.SaveChanges();
                return View();
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            using (IMDB_Context context = new IMDB_Context())
            {
                var arre=context.Actors.ToList<Actors>();
            }
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}