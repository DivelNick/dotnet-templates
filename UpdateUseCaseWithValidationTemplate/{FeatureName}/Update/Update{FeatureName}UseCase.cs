namespace Application.UseCases.{FeatureName}.Update;

/* Добавление структуры для Startup
    //update
    services.AddScoped<IValidator<Update{FeatureName}Input>, Update{FeatureName}FieldsValidator>();
    services.AddScoped<Update{FeatureName}FormatValidationHandler>();
    services.AddScoped<Update{FeatureName}ValidationHandler>();
    services.AddScoped<IValidationOrchestrator<Update{FeatureName}Input>, Update{FeatureName}ValidationOrchestrator>();
    services.AddScoped<IUpdate{FeatureName}UseCase, Update{FeatureName}UseCase>();
*/

public interface IUpdate{FeatureName}UseCase : ISimpleUseCase<ISimpleOutputPort<Update{FeatureName}ViewModel>, Update{FeatureName}Input>
{
}

public class Update{FeatureName}UseCase : SimpleUseCase<ISimpleOutputPort<Update{FeatureName}ViewModel>, Update{FeatureName}Input>, IUpdate{FeatureName}UseCase
{
    public Update{FeatureName}UseCase(IValidationOrchestrator<Update{FeatureName}Input> validator) : base(validator)
    {
    }

    public override Task ExecuteAfterInputModelValidation(Update{FeatureName}Input input)
    {
        throw new NotImplementedException();
    }
}