
using Microsoft.Maui;
using Microsoft.Maui.Hosting;

namespace MovieInventoryApp;

class Program : MauiApplication
{
    protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();

    static void Main(string[] args) => new Program().Run(args);
}
