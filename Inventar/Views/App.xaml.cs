using Inventar.Data;
using Inventar.Models;
using Inventar.Views;

namespace Inventar
{
    public partial class App : Application
    {

        public static AppDatabase? Database { get; private set; }
        public App()
        {
            InitializeComponent();
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "movies.db3");
            File.Delete(dbPath);
            Database = new AppDatabase(dbPath);

            var allTestMovies = TestMovieSeedData.GetMovies;

            Database.Movies.AddRange(allTestMovies);
            Database.SaveChanges();

            System.Diagnostics.Debug.WriteLine("Test movie inserted");
            System.Diagnostics.Debug.WriteLine("DB path: " + dbPath);

            MainPage = new NavigationPage(new LoginPage());

        }
    }
}
