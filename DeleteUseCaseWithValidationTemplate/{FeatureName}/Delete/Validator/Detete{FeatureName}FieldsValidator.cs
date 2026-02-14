using FluentValidation;

namespace Application.UseCases.{FeatureName}.Delete.Validator;

public class Delete{FeatureName}FieldsValidator : AbstractValidator<Delete{FeatureName}Input>
{
    public Delete{FeatureName}FieldsValidator()
    {
        RuleFor(x => x.Id)
            .NotNull()
            .NotEmpty();
    }
}