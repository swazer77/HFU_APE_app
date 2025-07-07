using System.Collections.ObjectModel;
using System.Windows.Input;
using MovieInventoryApp.Models;
using MovieInventoryApp.Services;
using MovieInventoryApp.Data;

namespace MovieInventoryApp.ViewModels
{
    public class MovieViewModel
    {
        public ObservableCollection<Movie> Movies { get; set; } = new ObservableCollection<Movie>();

        private AppDatabase _database;
        private AiService _aiService;

        public MovieViewModel(AppDatabase database, AiService aiService)
        {
            _database = database;
            _aiService = aiService;

            LoadMovies();
        }

        private void LoadMovies()
        {
            Movies.Clear();
            foreach (var movie in _database.Movies.ToList())
            {
                Movies.Add(movie);
            }
        }

        public async Task AddMovieAsync(string name, int year, string genre, double rating)
        {
            var aiData = await _aiService.FetchMovieDetailsAsync(name);

            var movie = new Movie
            {
                Name = name,
                Year = year,
                Genre = genre,
                Rating = rating,
                LastSeen = DateTime.Now,
                Description = aiData.Description,
                TrailerUrl = aiData.TrailerUrl,
                CoverImageUrl = aiData.CoverUrl
            };

            _database.Movies.Add(movie);
            _database.SaveChanges();

            Movies.Add(movie);
        }
    }
}