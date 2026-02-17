namespace Application.UseCases.{FeatureName}.Add.Validator;

public class Add{FeatureName}FieldsValidator : AbstractValidator<Add{FeatureName}Input>
{
    public Add{FeatureName}FieldsValidator()
    {
        RuleFor(x => x.Model)
            .NotNull()
            .WithMessage("Тело запроса не может быть null");
    }
}