using Inventar.Views;

namespace Inventar.Views;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
    }

    private async void OnLoginClicked(object sender, EventArgs e)
    {
        // TODO: Replace with real login check
        bool isValid = true;

        if (isValid)
        {
            Application.Current.MainPage = new NavigationPage(new MainPage());
        }
        else
        {
            await DisplayAlert("Login Failed", "Invalid credentials", "OK");
        }
    }
}