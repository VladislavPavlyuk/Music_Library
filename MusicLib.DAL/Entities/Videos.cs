
namespace MusicLib.DAL.Entities
{
    public class Video
    {
        public int Id { get; set; }

        public string? FileName { get; set; }

        public string? Path { get; set; }     

        public ICollection<Song>? Songs { get; set; }
    }
}
