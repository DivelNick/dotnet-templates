using System;
using FluentValidation;

namespace Application.UseCases.{FeatureName}.List.Validator;

public class {FeatureName}ListFieldsValidator : AbstractValidator<{FeatureName}ListInput>
{
    public {FeatureName}ListFieldsValidator()
    {
        RuleFor(x => x.Query)
            .NotNull()
            .WithMessage("Тело запроса не может быть null");
    }
}