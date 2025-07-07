using System.Collections.ObjectModel;
using System.Windows.Input;
using MovieInventoryApp.Models;
using MovieInventoryApp.Services;
using MovieInventoryApp.Data;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MovieInventoryApp.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Movie> Movies { get; set; } = new ObservableCollection<Movie>();

        private AppDatabase _database;
        private AiService _aiService;
        private string _searchText;
        public string SearchText
        {
            get => _searchText;
            set
            {
                _searchText = value;
                OnPropertyChanged();
                SearchMovies();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string name = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        public MainViewModel(AppDatabase db, AiService ai)
        {
            _database = db;
            _aiService = ai;
            LoadMovies();
        }

        public void LoadMovies()
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
            LoadMovies();
        }

        public void DeleteMovie(Movie movie)
        {
            _database.Movies.Remove(movie);
            _database.SaveChanges();
            LoadMovies();
        }

        public void SearchMovies()
        {
            var results = _database.Movies
                .Where(m => string.IsNullOrWhiteSpace(SearchText) || m.Name.Contains(SearchText))
                .ToList();

            Movies.Clear();
            foreach (var m in results)
            {
                Movies.Add(m);
            }
        }
    }
}