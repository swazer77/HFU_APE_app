using LZ1.Core;
using LZ1.Core.Services;
using Microsoft.Maui.Controls;

namespace LZ1.App;

public partial class MainPage : ContentPage
{
    private readonly ICounterService _counterService;

    public MainPage(ICounterService counterService)
    {
        _counterService = counterService ?? throw new ArgumentNullException(nameof(counterService));

        InitializeComponent();
    }

    private async void OnCounterClicked(object? sender, EventArgs e)
    {
        if (await _counterService.TryIncrement())
        {
            CounterBtn.Text = _counterService.GetLabel();

            SemanticScreenReader.Announce(CounterBtn.Text);
        }
    }

    private async void OnCounterClicked2(object? sender, EventArgs e)
    {
        if (await _counterService.TryDecrement())
        {
            CounterBtn2.Text = _counterService.GetLabel();

            SemanticScreenReader.Announce(CounterBtn.Text);
        }
    }
}