using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StudVoice.BLL.DTOs
{
    public class StringValueAttribute : System.Attribute
    {

        private string _value;

        public StringValueAttribute(string value)
        {
            _value = value;
        }

        public string Value
        {
            get { return _value; }
        }

    }
    public enum Faculties
    {
        //"Культури і мистецтв" 
        //"Журналістики",
        //"Прикладної математики та інформатики",
        //"Історичний"
        [StringValue("Культури і мистецтв")]
        Culture = 1,
        [StringValue("Журналістики")]
        Journalistics = 2,
        [StringValue("Прикладної математики та інформатики")]
        AMI = 3,
        [StringValue("Історичний")]
        History = 4,
    }
    public class RegisterTeacherDTO
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

        [Required]
        public string Email { get; set; }

        [Required]
        [RegularExpression("^[+][0-9]{12}", ErrorMessage = "Please enter a valid phone number in format +380931122334")]
        public string ContactPhone { get; set; }


        [Required]
        public Faculties Faculty { get; set; }

        [Required]
        [RegularExpression("^[a-zA-ZА-ЯҐЄІЇґєії]+$", ErrorMessage = "Please enter department in valid format.")]
        public string Department { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(255, ErrorMessage = "Must be between 6 and 255 characters", MinimumLength = 6)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Confirmation password isn`t mathes password")]
        public string ConfirmPassword { get; set; }

    }
}
