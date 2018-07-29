using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace MoviesDownload.Models
{
    public class Actors
    {
        public Actors()
        {
            this.Movies = new HashSet<Movies>();
        }
        

        [Key]
        public int ActorId { get; set; }

        public string Name { get; set; }
        public string Sex { get; set; }
        
        public DateTime DOB { get; set; }
        public string Bio { get; set; }

        public virtual ICollection<Movies> Movies { get; set; } = null;
    }
}