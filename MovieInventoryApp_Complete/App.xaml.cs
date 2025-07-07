using MovieInventoryApp.Data;
using MovieInventoryApp.Services;
using MovieInventoryApp.Views;

namespace MovieInventoryApp;

public partial class App : Application
{
    public static AppDatabase Database { get; private set; }
    public static AiService Ai { get; private set; }

    public App()
    {
        InitializeComponent();

        string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "movies.db3");
        Database = new AppDatabase(dbPath);
        Ai = new AiService();

        MainPage = new AppShell();
    }
}