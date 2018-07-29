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
    [KnownType(typeof(Producers))]
    public class Producers
    {
        public Producers()
        {
            this.Movies = new HashSet<Movies>();
        }
        [Key]
        public int ProducerId { get; set; } //= Guid.NewGuid();

        public string Name { get; set; }
        public string Sex { get; set; }
        public DateTime DOB { get; set; } = DateTime.Now;
        public string Bio { get; set; }

        //  public int MovieId { get; set; }
        public virtual ICollection<Movies> Movies { get; set; } = null;

    }
}