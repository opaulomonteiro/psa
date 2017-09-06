using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL.Models
{
    public interface IMovieDAO : IDisposable
    {
        IEnumerable<Movie> GetMovies();
        Movie GetMovieByID(int movieId);
        void Add(Movie movie);
        void Delete(int movieId);
        void Update(Movie movie);
    }
}
