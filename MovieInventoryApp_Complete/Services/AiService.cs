namespace MovieInventoryApp.Services
{
    public class AiService
    {
        public async Task<(string Description, string TrailerUrl, string CoverUrl)> FetchMovieDetailsAsync(string title)
        {
            // Placeholder for future AI integration
            await Task.Delay(500); // Simulate network delay
            return ($"{title} is a great movie.", "https://youtube.com/trailer", "https://example.com/cover.jpg");
        }
    }
}