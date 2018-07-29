using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MoviesDownload.Models
{
    public class IMDB_Context : DbContext
    {
        public IMDB_Context()
            : base("name=IMDB_Context")
        {

        }
        public DbSet<Actors> Actors { get; set; }
        public DbSet<Movies> Movies { get; set; }
        public DbSet<Producers> Producers { get; set; }

//        protected override void OnModelCreating(DbModelBuilder modelBuilder)
//        {
//            modelBuilder.Entity<Movies>()
//            .HasIndex(p => new { p.Name }).IsUnique();

//            modelBuilder.Entity<Producers>()
//.HasIndex(p => new { p.Name }).IsUnique();

//            base.OnModelCreating(modelBuilder);


//        }
    }

}