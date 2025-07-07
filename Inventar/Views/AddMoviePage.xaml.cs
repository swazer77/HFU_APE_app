using Inventar.Data;
using Inventar.Services;
using Inventar.ViewModels;

namespace Inventar.Views;

public partial class AddMoviePage : ContentPage
{
    public AddMoviePage()
    {
        InitializeComponent();
        var db = App.Database;
        var ai = new AiService();
        BindingContext = new AddMovieViewModel(db, ai);
    }
}