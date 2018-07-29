using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace MoviesDownload.Models
{
    [Serializable]
    [DataContract(IsReference = true)]
    [KnownType(typeof(Actors))]
    public class Actors
    {
      //  Movies movies = new Movies();
        public Actors()
        {
            this.Movies = new HashSet<Movies>();
        }
        

        [Key]
        public int ActorId { get; set; }// = Guid.NewGuid();

        public string Name { get; set; }
        public string Sex { get; set; }
        public DateTime DOB { get; set; }
        public string Bio { get; set; }

        // public int MovieId { get; set; }
        public virtual ICollection<Movies> Movies { get; set; } = null;
    }
}