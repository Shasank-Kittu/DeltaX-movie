using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using System.Web.Mvc;

namespace MoviesDownload.Models
{
    public class Movies
    {
        public Movies()
        {
            this.Actors = new HashSet<Actors>();
        }
        [Key]
        public int MovieId { get; set; }

        public string Name { get; set; }
        public DateTime Yearofrelease  { get; set; }
        public string Plot { get; set; }
        public string Poster { get; set; }

        public int ProducerId { get; set; }
        public  Producers Producer { get; set; }

        public virtual ICollection<Actors> Actors { get; set; }
    }
    public class MovieModel
    {
        public string Name { get; set; }
        public string Yearofrelease { get; set; }
        public string Plot { get; set; }
        public string Poster { get; set; }

        public IEnumerable<int> ActorsId { get; set; }
        public int ProducerId { get; set; }

        public List<SelectListItem> Producers { get; set; }
        public List<SelectListItem> Actors { get; set; }

    }
}