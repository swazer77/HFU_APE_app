using Inventar.Models;

namespace Inventar.Data
{
    public class TestMovieSeedData
    {
        public static List<Movie> GetMovies => new List<Movie>
        {
            new Movie { Name = "Debug Movie", Year = 2024, Genre = "Sci-Fi", Rating = 0, LastSeen = DateTime.Parse("2024-05-20") },
            new Movie { Name = "Skyfall", Year = 2012, Genre = "Action", Rating = 3, LastSeen = DateTime.Parse("2023-11-03") },
            new Movie { Name = "The Matrix", Year = 1999, Genre = "Sci-Fi", Rating = 2, LastSeen = DateTime.Parse("2022-07-15") },
            new Movie { Name = "The Grand Budapest Hotel", Year = 2014, Genre = "Comedy", Rating = 4, LastSeen = DateTime.Parse("2024-01-10") },
            new Movie { Name = "Whiplash", Year = 2014, Genre = "Drama", Rating = 5, LastSeen = DateTime.Parse("2023-09-21") },
            new Movie { Name = "Inception", Year = 2010, Genre = "Thriller", Rating = 4, LastSeen = DateTime.Parse("2024-03-05") },
            new Movie { Name = "Interstellar", Year = 2014, Genre = "Sci-Fi", Rating = 5, LastSeen = DateTime.Parse("2023-12-12") },
            new Movie { Name = "Coco", Year = 2017, Genre = "Animation", Rating = 4, LastSeen = DateTime.Parse("2022-10-28") },
            new Movie { Name = "Parasite", Year = 2019, Genre = "Thriller", Rating = 3, LastSeen = DateTime.Parse("2023-02-18") },
            new Movie { Name = "1917", Year = 2019, Genre = "War", Rating = 2, LastSeen = DateTime.Parse("2023-06-09") },
            new Movie { Name = "La La Land", Year = 2016, Genre = "Musical", Rating = 1, LastSeen = DateTime.Parse("2024-04-12") },
            new Movie { Name = "The Batman", Year = 2022, Genre = "Action", Rating = 2, LastSeen = DateTime.Parse("2024-02-22") },
            new Movie { Name = "Dune", Year = 2021, Genre = "Sci-Fi", Rating = 4, LastSeen = DateTime.Parse("2023-08-01") }
        };
    }
}
