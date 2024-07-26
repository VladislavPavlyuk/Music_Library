using System.ComponentModel.DataAnnotations;

namespace MusicLib.BLL.DTO
{
    // Data Transfer Object - специальная модель для передачи данных
    // Класс ArtistDTO должен содержать только те данные, которые нужно передать 
    // на уровень представления или, наоборот, получить с этого уровня.
    public class VideoDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено.")]
        public string? FileName { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено.")]
        public string? Path { get; set; }
    }
}
