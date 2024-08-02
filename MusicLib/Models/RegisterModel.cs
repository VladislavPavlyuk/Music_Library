using System.ComponentModel.DataAnnotations;

namespace MusicLib.Models
{
    public class RegisterModel
    {
        [Required]
        public string? Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Required]
        [Compare("Password")]
        [DataType(DataType.Password)]
        public string? PasswordConfirm { get; set; }
    }
}
