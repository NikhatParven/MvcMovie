using Microsoft.CodeAnalysis.CSharp.Syntax;
using MvcMovie.Models;
using System.Collections.Generic;

namespace MvcMovie.Data
{
    public class FakeContext
    {
        public List<Movie> Movie { get; set; }
        public FakeContext()
        {
            Movie = new List<Movie>()
            {
                new Movie
                {
                    Id = 1,
                    Title = "Avatar: The way of water",
                    ReleaseDate = DateTime.Parse("2022,12,25"),
                    Genre = "Fiction",
                    Price = 49.99M
                },
                new Movie
                {
                    Id = 2,
                    Title = "Titanic",
                    ReleaseDate = DateTime.Parse("1997,01,01"),
                    Genre = "Drama",
                    Price = 99.99M
                }
            };
        }

        public async Task AddAsync(Movie movie) 
            => await Task.Run(() => Movie.Add(movie));

        public void Update(Movie movie)
        {
            //todo: implement later            
            return;
        }
    }
}
