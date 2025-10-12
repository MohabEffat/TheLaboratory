namespace Movies.API.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; } = default!;
        public string Director { get; set; } = default!;
        public DateTime ReleaseDate { get; set; }
        public string Genre { get; set; } = default!;

    }
}
