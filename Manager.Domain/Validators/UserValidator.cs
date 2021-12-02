using FluentValidation;
using Manager.Domain.Entities;

namespace Manager.Domain.Validators
{
  public class UserValidator : AbstractValidator<User>
  {
    public UserValidator()
    {
      RuleFor(x => x)
        .NotEmpty()
        .WithMessage("the entity can not be empty")

        .NotNull()
        .WithMessage("the entity can not be null");

      RuleFor(x => x.Name)
        .NotEmpty()
        .WithMessage("the name can not be empty")

        .NotNull()
        .WithMessage("the name can not be null")

        .MinimumLength(3)
        .WithMessage("the minimum name lenght can not be less 3")

        .MaximumLength(80)
        .WithMessage("the maximum name lenght can not be better 80");

      RuleFor(x => x.Email)
        .NotEmpty()
        .WithMessage("the email can not be empty")

        .NotNull()
        .WithMessage("the email can not be null")

        .MinimumLength(10)
        .WithMessage("the minimum email lenght can not be less 10")

        .MaximumLength(180)
        .WithMessage("the maximum email lenght can not be better 180")

        .Matches(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$")
        .WithMessage("the email entered is invalid");

      RuleFor(x => x.Password)
        .NotEmpty()
        .WithMessage("the password can not be empty")

        .NotNull()
        .WithMessage("the password can not be null")

        .MinimumLength(6)
        .WithMessage("the minimum password lenght can not be less 6")

        .MaximumLength(30)
        .WithMessage("the maximum password lenght can not be better 30");
    }
  }
}
