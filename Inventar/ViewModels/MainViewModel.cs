using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Inventar.Data;
using Inventar.Models;
using Inventar.Services;
// ReSharper disable FieldCanBeMadeReadOnly.Local

namespace Inventar.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Movie> Movies { get; set; } = new ObservableCollection<Movie>();

        private AppDatabase database;
        //private JsonMovieService service = new JsonMovieService();
        private AiService aiService;
        private string searchText;

        public string SearchText
        {
            get => searchText;
            set
            {
                searchText = value;
                OnPropertyChanged();
                SearchMovies();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string name = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        public MainViewModel(AppDatabase db, AiService ai)
        {
            database = db;
            aiService = ai;
            LoadMovies();
        }

        public void LoadMovies()
        {
            //SQLite
            Movies.Clear();
            foreach (var movie in database.Movies.ToList())
            {
                Movies.Add(movie);
            }
            
            /* json
            var loaded = await service.GetAllMoviesAsync();
            Movies.Clear();
            foreach (var movie in loaded)
                Movies.Add(movie);
            */
        }

        public void DeleteMovie(Movie movie)
        {
            // SQLite
            database.Movies.Remove(movie);
            database.SaveChanges();
            LoadMovies();

            /* json
            await service.DeleteMovieAsync(movie);
            LoadMovies();
            */
        }

        public void SearchMovies()
        {
            var results = database.Movies
                .Where(m => string.IsNullOrWhiteSpace(SearchText) || m.Name.ToLower().Contains(SearchText.ToLower()))
                .ToList();

            Movies.Clear();
            foreach (var m in results)
            {
                Movies.Add(m);
            }
        }
    }
}