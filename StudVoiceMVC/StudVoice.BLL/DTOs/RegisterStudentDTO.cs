using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StudVoice.BLL.DTOs
{
    public class RegisterStudentDTO
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public string Patronym { get; set; }//по батькові

        [Required]
        public string Faculty { get; set; }

        [Required]
        public string Email { get; set; }
        [Required]
        public string ContactPhone { get; set; }

        [Required]
        public string Password { get; set; }

        public string ConfirmPassword { get; set; }
    }
}
