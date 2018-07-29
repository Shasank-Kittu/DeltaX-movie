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

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    // configures one-to-many relationship
        //    modelBuilder.Entity<Movies>()
        //        .HasRequired<Producers>(s => s.Producer)
        //        .WithMany(g => g.Movies)
        //        .HasForeignKey<int>(s => s.ProducerId);

        //    modelBuilder.Entity<Movies>()
        //    .HasMany<Actors>(s => s.Actors)
        //    .WithMany(c => c.Movies)
        //    .Map(cs =>
        //    {
        //        cs.MapLeftKey("MoviesRefId");
        //        cs.MapRightKey("ActorsRefId");
        //        cs.ToTable("MovieActor");
        //    });
        //}
    }

}