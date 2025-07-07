using Inventar.Data;
using Inventar.Models;
using Inventar.Services;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Inventar.ViewModels
{
    public class AddMovieViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string name = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        private readonly AppDatabase database;
        private readonly AiService aiService;


        private string name;
        private string serie;
        private int year;
        private string genre;
        public string Name
        {
            get => name;
            set { name = value; OnPropertyChanged(); }
        }

        public string Serie
        {
            get => serie;
            set { serie = value; OnPropertyChanged(); }
        }

        public int Year
        {
            get => year;
            set { year = value; OnPropertyChanged(); }
        }

        public string Genre
        {
            get => genre;
            set { genre = value; OnPropertyChanged(); }
        }

        public ICommand SaveCommand { get; }

        public AddMovieViewModel(AppDatabase database, AiService aiService)
        {
            this.database = database;
            this.aiService = aiService;
            SaveCommand = new Command(async () => await SaveMovieAsync());
        }

        private async Task SaveMovieAsync()
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                await ShowValidationError("Name is required.");
                return;
            }

            if (Year <= 1900)
            {
                await ShowValidationError("Year is required and must be greater than 1900.");
                return;
            }

            if (string.IsNullOrWhiteSpace(Genre))
            {
                await ShowValidationError("Genre is required.");
                return;
            }

            var aiData = await aiService.FetchMovieDetailsAsync(Name);

            var movie = new Movie
            {
                Name = Name,
                Serie = Serie,
                Year = Year,
                Genre = Genre,
                Rating = 0,
                LastSeen = null,
                Description = aiData.Description,
                TrailerUrl = aiData.TrailerUrl,
                CoverImageUrl = aiData.CoverUrl
            };

            database.Movies.Add(movie);
            await database.SaveChangesAsync();

            System.Diagnostics.Debug.WriteLine($"Movie {Name} added.");

           await Application.Current.MainPage.Navigation.PopAsync();
        }

        private async Task ShowValidationError(string message)
        {
            await Application.Current.MainPage.DisplayAlert("Validation Error", message, "OK");
        }
    }
}