using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StudVoice.BLL.DTOs
{
    public class RegisterStudentDTO
    {
        [Required]
        [RegularExpression("^[a-zA-ZА-ЯҐЄІЇґєії]+$", ErrorMessage = "Please enter name in valid format.")]
        public string Name { get; set; }

        [Required]
        [RegularExpression("^[a-zA-ZА-ЯҐЄІЇґєії]+$", ErrorMessage = "Please enter surname in valid format.")]
        public string Surname { get; set; }

        [Required]
        [RegularExpression("^[a-zA-ZА-ЯҐЄІЇґєії]+$", ErrorMessage = "Please enter patronym in valid format.")]
        public string Patronym { get; set; }//по батькові

        //[Required]
        public string Faculty { get; set; }

        [Required]
        public string Email { get; set; }
        [Required]
        [RegularExpression("^[+][0-9]{12}", ErrorMessage = "Please enter a valid phone number in format +380931122334")]
        public string ContactPhone { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(255, ErrorMessage = "Must be between 6 and 255 characters", MinimumLength = 6)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Confirmation password isn`t mathes password")]
        public string ConfirmPassword { get; set; }
    }
}
