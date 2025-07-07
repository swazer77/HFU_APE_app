using System.Diagnostics;
using System.Text.Json;
using Inventar.Models;

namespace Inventar.Services;

public class JsonMovieService
{
    private readonly string filePath;

    public JsonMovieService()
    {
        //filePath = Path.Combine(FileSystem.AppDataDirectory, "db.json");
        filePath = @"C:\Users\gamer\OffDrive\project\HFU_APE_app\Inventar\data\db.json";
        Debug.WriteLine($"PATH:: {filePath}");
        if (!File.Exists(filePath))
        {
            File.WriteAllText(filePath, "[]");
        }
    }

    public async Task<List<Movie>> GetAllMoviesAsync()
    {
        var json = await File.ReadAllTextAsync(filePath);
        return JsonSerializer.Deserialize<List<Movie>>(json) ?? new List<Movie>();
    }

    public async Task SaveAllMoviesAsync(List<Movie> movies)
    {
        var json = JsonSerializer.Serialize(movies, new JsonSerializerOptions { WriteIndented = true });
        await File.WriteAllTextAsync(filePath, json);
    }

    public async Task AddOrUpdateMovieAsync(Movie movie)
    {
        var movies = await GetAllMoviesAsync();

        var existing = movies.FirstOrDefault(m => m.Id == movie.Id);
        if (existing != null)
        {
            movies.Remove(existing);
        }
        else
        {
            // Generate ID
            movie.Id = (movies.Max(m => (int?)m.Id) ?? 0) + 1;
        }

        movies.Add(movie);
        await SaveAllMoviesAsync(movies);
    }

    public async Task DeleteMovieAsync(Movie movie)
    {
        var movies = await GetAllMoviesAsync();
        movies.RemoveAll(m => m.Id == movie.Id);
        await SaveAllMoviesAsync(movies);
    }
}