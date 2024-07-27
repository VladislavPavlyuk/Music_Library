using System.ComponentModel.DataAnnotations;

namespace MusicLib.BLL.DTO
{
    // Data Transfer Object - специальная модель для передачи данных
    // Класс GenreDTO должен содержать только те данные, которые нужно передать 
    // на уровень представления или, наоборот, получить с этого уровня.
    public class GenreDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Requred!")]
        public string? Name { get; set; }

    }
}
