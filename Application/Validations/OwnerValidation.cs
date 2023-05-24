﻿using Domain.Entities;
using FluentValidation;

namespace Application.Validations;

public class OwnerValidation : AbstractValidator<Owner>
{
    public OwnerValidation()
    {
        RuleFor(x => x.Username)
            .NotEmpty()
            .NotNull()
            .MaximumLength(20)
            .MinimumLength(5)
            .WithMessage("Username is not valid");
        RuleFor(x => x.FullName)
           .NotEmpty()
           .NotNull()
           .MaximumLength(20)
           .MinimumLength(5)
           .WithMessage("FullName is not valid");

        RuleFor(x => x.Password)
          .NotEmpty()
          .NotNull()
          .Matches("^(?=.*[A-Za-z])(?=.*\\d)[A-Za-z\\d]{8,}$")
            .WithMessage("Password is not valid")
          .MinimumLength(6)
          .WithMessage("Password is not valid");

        RuleForEach(x => x.PhoneNumbers)
            .Matches(@"^\+998\d{9}$")
              .WithMessage("PhoneNumbers is not valid");
    }
}
