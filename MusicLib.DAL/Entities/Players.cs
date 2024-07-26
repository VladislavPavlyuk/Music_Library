namespace MusicLib.DAL.Entities
{
    public class Player
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public int Age { get; set; }

        public string? Position { get; set; }

        public int? GenreId { get; set; }

        public Genre? Genre { get; set; }
    }
}
