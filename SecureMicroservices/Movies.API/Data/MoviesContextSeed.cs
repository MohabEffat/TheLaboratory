using Movies.API.Models;
using System.Text.Json;

namespace Movies.API.Data
{
    public class MoviesContextSeed
    {
        public static async Task SeedAsync(MoviesAPIContext context)
        {
            try
            {
                if (!context.Movie.Any())
                {
                    var moviesJson = await File.ReadAllTextAsync("Data/movies.json");

                    var movies = JsonSerializer.Deserialize<List<Movie>>(moviesJson);

                    context.Movie.AddRange(movies!);

                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
