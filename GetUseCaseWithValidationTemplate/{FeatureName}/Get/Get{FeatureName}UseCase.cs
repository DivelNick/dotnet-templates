namespace Application.UseCases.{FeatureName}.Get;

/* Добавление структуры для Startup    
    //get 
    services.AddScoped<IValidator<Get{FeatureName}Input>, Get{FeatureName}FieldsValidator>();
    services.AddScoped<Get{FeatureName}FormatValidationHandler>();
    services.AddScoped<Get{FeatureName}ValidationHandler>();
    services.AddScoped<IValidationOrchestrator<Get{FeatureName}Input>, Get{FeatureName}ValidationOrchestrator>();
    services.AddScoped<IGet{FeatureName}UseCase, Get{FeatureName}UseCase>();
*/
public interface IGet{FeatureName}UseCase : ISimpleUseCase<ISimpleOutputPort<Get{FeatureName}ViewModel>, Get{FeatureName}Input>
{
}

public class Get{FeatureName}UseCase : SimpleUseCase<ISimpleOutputPort<Get{FeatureName}ViewModel>, Get{FeatureName}Input>, IGet{FeatureName}UseCase
{
    public Get{FeatureName}UseCase(IValidationOrchestrator<Get{FeatureName}Input> validator) : base(validator)
    {
    }

    public override async Task ExecuteAfterInputModelValidation(Get{FeatureName}Input input)
    {
        throw new NotImplementedException();
    }
}