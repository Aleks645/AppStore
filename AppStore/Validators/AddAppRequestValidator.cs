using System;
using AppStore.Models.Models;
using FluentValidation;

namespace AppStore.Validators;

public class AddAppValidator : AbstractValidator<App>
{
    public AddAppValidator(){
        RuleFor(x => x.Name)
            .NotEmpty()
            .NotNull()
            .MaximumLength(20)
            .MinimumLength(2).WithMessage("App name must be at least 2 characters.");

        RuleForEach(x => x.OperatingSystems)
            .NotEmpty()
            .NotNull();
    }

}
