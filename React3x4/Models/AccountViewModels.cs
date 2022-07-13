using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace React3x4.Models
{
    public class RegisterViewModel
    {
        public string? UserName { get; set; }
        //[Display(Name = "Email")]
        //[Required(ErrorMessage = "Обов'язкове поле")]
        //[EmailAddress(ErrorMessage = "Не коректна пошта")]
        public string? Email { get; set; }

        //[Display(Name = "Password")]
        //[DataType(DataType.Password)]
        //[Required(ErrorMessage = "Неправильний пароль")]
        public string? Password { get; set; }
        public string? ConfirmPassword { get; set; }
        //public string? Photo { get; set; }


    }

    
}
