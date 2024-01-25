using System.ComponentModel.DataAnnotations;

namespace ExamDoorang.Areas.Admin.ViewModels
{
    public class LoginVM
    {
        [MinLength(5, ErrorMessage = "Username lenght cant be less 5")]
        [MaxLength(320, ErrorMessage = "Username lenght cant be longer than 320")]
        public string UserNameorEmail { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool isPersistence { get; set; }


    }
}
