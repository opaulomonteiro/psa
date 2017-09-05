using PL.Models;
using System;

namespace Exercicio_1Movies
{
    class Program
    {
        static void Main(string[] args)
        {

            var movieDao = new MovieDao();

            var movie1 = new Movie()
            {
                Title = "Logan",
                Director = "James Mangold",
                Rating = 8.5,
                ReleaseDate = new DateTime(2017, 03, 24),
                GenreID = 1
            };
            var movie2 = new Movie()
            {
                Title = "Tarzan",
                Director = "Teste",
                Rating = 6.5,
                ReleaseDate = new DateTime(2017, 03, 24),
                GenreID = 2
            };

            movieDao.Add(movie1);
            movieDao.Add(movie2);

            movie1.Rating = 6.5;

            movieDao.Update(movie1);


            movieDao.Delete(movie2.ID);          
               

              
            }

        }
    }

