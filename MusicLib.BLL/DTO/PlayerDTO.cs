using System.ComponentModel.DataAnnotations;

namespace MusicLib.BLL.DTO
{
    // Data Transfer Object - специальная модель для передачи данных
    // Класс PlayerDTO должен содержать только те данные, которые нужно передать 
    // на уровень представления или, наоборот, получить с этого уровня.
    public class PlayerDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено.")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено.")]
        public string? Position { get; set; }

        public int? TeamId { get; set; }

        public string? Team { get; set; }
    }
}
