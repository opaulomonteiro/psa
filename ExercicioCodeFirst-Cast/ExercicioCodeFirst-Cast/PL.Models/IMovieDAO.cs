using System;
using System.Collections.Generic;

namespace PL.Models
{
    public interface IMovieDAO : IDisposable
    {
        IEnumerable<Movie> GetMovies();
        Movie GetMovieByID(int movieId);
        void Add(Movie movie);
        void Delete(int movieId);
        void Update(Movie movie);
        IEnumerable<Movie> FindMovieByGenre(String genreTitle);
    }
}
