namespace Application.UseCases.{FeatureName}.Get;

public interface IGet{FeatureName}UseCase : ISimpleUseCase<ISimpleOutputPort<Get{FeatureName}ViewModel>, Get{FeatureName}Input>
{
}

public class Get{FeatureName}UseCase : SimpleUseCase<ISimpleOutputPort<Get{FeatureName}ViewModel>, Get{FeatureName}Input>, IGet{FeatureName}UseCase
{
    public Get{FeatureName}UseCase(IValidationOrchestrator<Get{FeatureName}Input> validator) : base(validator)
    {
    }

    public override Task ExecuteAfterInputModelValidation(Get{FeatureName}Input input)
    {
        throw new NotImplementedException();
    }
}