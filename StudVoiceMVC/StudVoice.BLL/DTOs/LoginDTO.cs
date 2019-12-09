using System.ComponentModel.DataAnnotations;

namespace StudVoice.BLL.DTOs
{
    public class LoginDTO
    {
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
    }
}