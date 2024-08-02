using System.ComponentModel.DataAnnotations;

namespace MusicLib.BLL.DTO
{
    // Data Transfer Object - специальная модель для передачи данных
    // Класс SongDTO должен содержать только те данные, которые нужно передать 
    // на уровень представления или, наоборот, получить с этого уровня.
    public class UserDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Requred!")]
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Salt { get; set; }

        public int? RoleId { get; set; }
        public string? Role { get; set; }
    }
}
