using Inventar.Data;
using Inventar.Models;
using Inventar.Services;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Inventar.ViewModels
{
    internal class EditMovieViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public Movie Movie { get; set; }
        private AppDatabase db;
        //private JsonMovieService service;
        public ICommand SaveCommand { get; }
        public ICommand CancelCommand { get; }
        public ICommand DeleteCommand { get; }
        public ICommand SetRatingCommand { get; }

        public string Star1 => Movie.Rating >= 1 ? "star_filled.png" : "star_outline.png";
        public string Star2 => Movie.Rating >= 2 ? "star_filled.png" : "star_outline.png";
        public string Star3 => Movie.Rating >= 3 ? "star_filled.png" : "star_outline.png";
        public string Star4 => Movie.Rating >= 4 ? "star_filled.png" : "star_outline.png";
        public string Star5 => Movie.Rating >= 5 ? "star_filled.png" : "star_outline.png";


        public INavigation Navigation { get; set; }

        public EditMovieViewModel(Movie movie, AppDatabase db, INavigation nav)
        {
            Movie = movie;
            this.db = db;
            //service = new JsonMovieService();
            Navigation = nav;

            SetRatingCommand = new Command<object>(SetRating);
            SaveCommand = new Command(Save);
            CancelCommand = new Command(async () => await Navigation.PopAsync());
            DeleteCommand = new Command(Delete);
        }

        private async void Save()
        {
            // SQLite
            db.Movies.Update(Movie);
            await db.SaveChangesAsync();
            await Navigation.PopAsync();

            /* json
            await service.AddOrUpdateMovieAsync(Movie);
            await Navigation.PopAsync();
            */
        }

        private void SetRating(object obj)
        {
            if (obj is string str && int.TryParse(str, out int rating))
            {
                Debug.WriteLine($"Input {rating}, Old {Movie.Rating}");
                if (Movie.Rating == rating)
                {
                    Movie.Rating = null;
                }
                else
                {
                    Debug.WriteLine($"Star {rating} clicked!");
                    Movie.Rating = rating;
                    
                    Debug.WriteLine($"Rating: {Movie.Rating}");
                }
                OnPropertyChanged(nameof(Star1));
                OnPropertyChanged(nameof(Star2));
                OnPropertyChanged(nameof(Star3));
                OnPropertyChanged(nameof(Star4));
                OnPropertyChanged(nameof(Star5));
            }
        }

        private async void Delete()
        {
            // SQLite
            db.Movies.Remove(Movie);
            await db.SaveChangesAsync();
            await Navigation.PopAsync();

            /* json
            await service.DeleteMovieAsync(Movie);
            await Navigation.PopAsync();
            */
        }

        void OnPropertyChanged([CallerMemberName] string name = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

    }
}
