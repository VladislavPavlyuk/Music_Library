namespace MusicLib.DAL.Entities
{
    public class Song
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Release { get; set; }

        public Genre? Genre { get; set; }
        public int? GenreId { get; set; }

        public Artist? Artist { get; set; }
        public int? ArtistId { get; set; }

        public Video? Video { get; set; }
        public int? VideoId { get; set; }
    }
}
