﻿using System.Data.Entity;

namespace PL.Models
{
    public class MovieContext : DbContext
    {
        public MovieContext() : base("MovieContext") { }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }

        public DbSet<Actor> Actors { get; set; }
        public DbSet<ActorMovie> Characters { get; set; }
    }
}
    