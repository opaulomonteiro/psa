using PL.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercicio_1Movies
{
    class MovieDao : IMovieDAO
    {
        public void Add(Movie movie)
        {
            using (var contexto = new MovieContext())
            {
                contexto.Database.Log = Console.Write;
                contexto.Movies.Add(movie);
                contexto.SaveChanges();
            }
        }

        public void Delete(int movieId)
        {
            using (var contexto = new MovieContext())
            {
                contexto.Database.Log = Console.Write;

                var movieToDelete = GetMovies().ToList().Find(movie => movie.ID == movieId);

                if(movieToDelete != null)
                {
                    contexto.Movies.Attach(movieToDelete);
                    contexto.Movies.Remove(movieToDelete);

                    contexto.SaveChanges();
                }else
                {
                    throw new Exception("Não achou o filme na base");
                }
                
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Movie GetMovieByID(int movieId)
        {
            var findedMovie = new Movie();

            using (var contexto = new MovieContext())
            {
                contexto.Database.Log = Console.Write;
                var listaFilmes = GetMovies().ToList();

                findedMovie = listaFilmes.Find(movie => movie.ID == movieId);
            }

            return findedMovie;
        }

        public IEnumerable<Movie> GetMovies()
        {
            var listaFilmes = new List<Movie>();
            using(var contexto = new MovieContext())
             {
                contexto.Database.Log = Console.Write;
                listaFilmes = contexto.Movies.ToList();                
            }
            return listaFilmes;
        }

        public void Update(Movie movie)
        {
            using (var contexto = new MovieContext())
            {
                contexto.Database.Log = Console.Write;
                var listaFilmes = GetMovies();
                Movie movieFromDb = listaFilmes.Where(f => f.ID == movie.ID).First();
                if(movieFromDb != null)
                {
                    movieFromDb = movie;
                }
                contexto.SaveChanges();
            }            
        }
    }
}
