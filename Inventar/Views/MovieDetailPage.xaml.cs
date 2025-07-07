using Inventar.Models;
using Inventar.ViewModels;
using Microsoft.Maui.Controls;
using System.Diagnostics;

namespace Inventar.Views
{
    public partial class MovieDetailPage : ContentPage
    {
        public MovieDetailPage(Movie movie)
        {
            InitializeComponent();
            BindingContext = new EditMovieViewModel(movie, App.Database, Navigation);
            Debug.WriteLine("EditMovieViewModel is now active");
        }

        private void OnStarClicked(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Star clicked");
        }
    }
}