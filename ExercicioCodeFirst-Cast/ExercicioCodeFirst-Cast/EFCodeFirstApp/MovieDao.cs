using PL.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EFCodeFirstApp
{
    class MovieDao : IMovieDAO
    {
        public void Add(Movie movie)
        {
            using (var contexto = new MovieContext())
            {
                contexto.Movies.Add(movie);
                contexto.SaveChanges();
            }
        }

        public void Delete(int movieId)
        {
            try
            {
                using (var contexto = new MovieContext())
                {

                    #region Solução com acesso ao banco para buscar a Lista de Movies
                        // var movieToDelete = contexto.Movies.Find(movieId); 
                        //if (movieToDelete != null)
                        //{                   
                        //    contexto.Movies.Remove(movieToDelete);
                        //    contexto.SaveChanges();
                        //}
                        //else
                        //{
                        //    throw new Exception("Não achou o filme na base");
                        //}
                    #endregion

                    #region Solução sem acesso ao banco para buscar a Lista de Movies
                        var movieToDelete = new Movie() { ID = movieId };
                        contexto.Movies.Attach(movieToDelete);
                        contexto.Movies.Remove(movieToDelete);
                        contexto.SaveChanges();
                    #endregion
                }
            }
            catch
            {
                Console.Write("Ocorreu um erro ao tentar deletar o filme com ID " + movieId);
            }
        }

        public void Dispose()
        {
           
        }

        public IEnumerable<Movie> FindMovieByGenre(string genreTitle)
        {
            var findedMovies = new List<Movie>();

            using (var contexto = new MovieContext())
            {
                var listaFilmes = GetMovies().ToList();

                findedMovies = listaFilmes.FindAll(movie => movie.Genre.Name == genreTitle);
            }

            return findedMovies;
        }

        public Movie GetMovieByID(int movieId)
        {
            var findedMovie = new Movie();

            using (var contexto = new MovieContext())
            {
                var listaFilmes = GetMovies().ToList();

                findedMovie = listaFilmes.Find(movie => movie.ID == movieId);
            }

            return findedMovie;
        }

        public IEnumerable<Movie> GetMovies()
        {
            var listaFilmes = new List<Movie>();
            using (var contexto = new MovieContext())
            {
                listaFilmes = contexto.Movies.ToList();
            }
            return listaFilmes;
        }

        public void Update(Movie movie)
        {
            using (var contexto = new MovieContext())
            {
                var listaFilmes = GetMovies();
                Movie movieFromDb = listaFilmes.Where(f => f.ID == movie.ID).First();
                if (movieFromDb != null)
                {
                    movieFromDb = movie;
                }
                contexto.SaveChanges();
            }
        }
    }
}
