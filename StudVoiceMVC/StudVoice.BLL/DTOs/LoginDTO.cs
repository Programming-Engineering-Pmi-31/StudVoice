using System.ComponentModel.DataAnnotations;

namespace StudVoice.BLL.DTOs
{
    public class LoginDTO
    {
        [Required]
        public string Login { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}