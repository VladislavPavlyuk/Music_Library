using System.ComponentModel.DataAnnotations;

namespace MusicLib.BLL.DTO
{
    // Data Transfer Object - специальная модель для передачи данных
    // Класс SongDTO должен содержать только те данные, которые нужно передать 
    // на уровень представления или, наоборот, получить с этого уровня.
    public class SongDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Requred!")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Requred!")]
        public string? Release { get; set; }

        public int? GenreId { get; set; }
        public string? Genre { get; set; }

        public int? ArtistId { get; set; }
        public string? Artist { get; set; }

        public int? VideoId { get; set; }
        public string? Video { get; set; }
    }
}
