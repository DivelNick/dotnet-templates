namespace Application.UseCases.{FeatureName}.Add;

public interface IAdd{FeatureName}UseCase : ISimpleUseCase<ISimpleOutputPort<bool>, Add{FeatureName}Input>
{
}

public class Add{FeatureName}UseCase : SimpleUseCase<ISimpleOutputPort<bool>, Add{FeatureName}Input>, IAdd{FeatureName}UseCase
{
    public Add{FeatureName}UseCase(IValidationOrchestrator<Add{FeatureName}Input> validator) : base(validator)
    {
    }

    public override Task ExecuteAfterInputModelValidation(Add{FeatureName}Input input)
    {
        throw new NotImplementedException();
    }
}