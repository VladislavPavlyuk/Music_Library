
namespace MusicLib.DAL.Entities
{
    public class Artist
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Birthdate { get; set; }

        public ICollection<Song>? Songs { get; set; }
    }
}
