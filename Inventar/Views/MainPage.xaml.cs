using Inventar.ViewModels;
using Inventar.Data;
using Inventar.Models;
using Inventar.Services;

namespace Inventar.Views;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();

        var db = App.Database;
        var ai = new AiService();

        BindingContext = new MainViewModel(db, ai);
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        if (BindingContext is MainViewModel viewModel)
        {
            viewModel.LoadMovies();
        }
    }

    private async void OnAddMovieClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddMoviePage());
    }

    private async void OnMovieTapped(object sender, TappedEventArgs e)
    {
        if (e.Parameter is Movie selectedMovie)
        {
            await Navigation.PushAsync(new MovieDetailPage(selectedMovie));
        }
    }

    private async void OnMovieDoubleTapped(object sender, EventArgs e)
    {
        if (sender is VisualElement ve && ve.BindingContext is Movie movie)
        {
            bool confirm = await DisplayAlert("Delete Movie", $"Delete '{movie.Name}'?", "Yes", "No");
            if (confirm)
            {
                App.Database.Movies.Remove(movie);
                App.Database.SaveChanges();

                // Refresh
                if (BindingContext is MainViewModel vm)
                    vm.LoadMovies();
            }
        }
    }
}