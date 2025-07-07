namespace MovieInventoryApp;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
        Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
        Routing.RegisterRoute(nameof(AddMoviePage), typeof(AddMoviePage));
        Routing.RegisterRoute(nameof(MovieDetailPage), typeof(MovieDetailPage));
    }
}