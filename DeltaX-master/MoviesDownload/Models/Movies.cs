using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace MoviesDownload.Models
{
    [Serializable]
    [DataContract(IsReference = true)]
    [KnownType(typeof(Movies))]
    public class Movies
    {
        public Movies()
        {
            this.Actors = new HashSet<Actors>();
        }
        [Key]
        public int MovieId { get; set; }// = Guid.NewGuid();

        public string Name { get; set; }
        public DateTime Yearofrelease  { get; set; }
        public string Plot { get; set; }
        public string Poster { get; set; }

        public int ProducerId { get; set; }
        public  Producers Producer { get; set; }

        //  public int ActorId { get; set; }
        public virtual ICollection<Actors> Actors { get; set; } = null;
    }
}