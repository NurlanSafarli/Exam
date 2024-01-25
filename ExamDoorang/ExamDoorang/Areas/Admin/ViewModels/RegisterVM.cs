using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = Microsoft.Build.Framework.RequiredAttribute;

namespace ExamDoorang.Areas.Admin.ViewModels
{
    public class RegisterVM
    {
        [Required]
        [MinLength( 3,ErrorMessage = "Name lenght cant be less 3")]
        [MaxLength(50, ErrorMessage ="Name lenght cant be longer than 50")]

        public string Name { get; set; }
        [MinLength(3, ErrorMessage = "Surname lenght cant be less 3")]
        [MaxLength(50, ErrorMessage = "Surname lenght cant be longer than 50")]
        public string Surname { get; set; }
        [MinLength(5, ErrorMessage = "Username lenght cant be less 5")]
        [MaxLength(320, ErrorMessage = "Username lenght cant be longer than 320")]
        public string UserName { get; set; }
        [RegularExpression("(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|\"(?:[\\x01-\\x08\\x0b\\x0c\\x0e-\\x1f\\x21\\x23-\\x5b\\x5d-\\x7f]|\\\\[\\x01-\\x09\\x0b\\x0c\\x0e-\\x7f])*\")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\\[(?:(?:(2(5[0-5]|[0-4][0-9])|1[0-9][0-9]|[1-9]?[0-9]))\\.){3}(?:(2(5[0-5]|[0-4][0-9])|1[0-9][0-9]|[1-9]?[0-9])|[a-z0-9-]*[a-z0-9]:(?:[\\x01-\\x08\\x0b\\x0c\\x0e-\\x1f\\x21-\\x5a\\x53-\\x7f]|\\\\[\\x01-\\x09\\x0b\\x0c\\x0e-\\x7f])+)\\])")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DataType(DataType.Password)]

        public string Password { get; set; }
        [DataType(DataType.Password)]


        public string ConfirmPassword { get; set; }

    }
}
