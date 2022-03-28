using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace React3x4.Models
{
    public class RegisterViewModel
    {
        //[Display(Name = "Email")]
        //[Required(ErrorMessage = "Обов'язкове поле")]
        //[EmailAddress(ErrorMessage = "Не коректна пошта")]
        public string Email { get; set; }

        //[Display(Name = "Password")]
        //[DataType(DataType.Password)]
        //[Required(ErrorMessage = "Неправильний пароль")]
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }

    public class AccountValidator : AbstractValidator<RegisterViewModel>
    {
        public AccountValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Поле Email не може бути порожнім")
                .MinimumLength(6)
                .EmailAddress()
                .WithMessage("Помилка заповнення поля Email");
            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Поле Password не може бути порожнім")
                .MinimumLength(5)
                .WithMessage("Пароль не може бути коротший, ніж 5 символів")
                .Matches(@"\d")
                .WithName("Password")
                .WithMessage("Пароль повинен містити хоча б одну цифру");
            RuleFor(x => x.ConfirmPassword)
                .NotEmpty()
                .WithMessage("Поле ConfirmPassword не може бути порожнім")
                .Equal(x => x.Password)
                .WithMessage("Введене підтвердження не співпадає з паролем");

        }
    }
}
