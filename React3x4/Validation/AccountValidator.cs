using FluentValidation;
using React3x4.Models;

namespace React3x4.Validation
{
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
