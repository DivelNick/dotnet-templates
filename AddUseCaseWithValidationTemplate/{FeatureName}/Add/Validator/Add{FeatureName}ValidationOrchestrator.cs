namespace Application.UseCases.{FeatureName}.Add.Validator;

public class Add{FeatureName}ValidationOrchestrator(IValidationHandler<Add{FeatureName}Input> validationChain)
    : ValidationOrchestratorBase<Add{FeatureName}Input>(validationChain)
{
}

public class Add{FeatureName}FormatValidationHandler(IValidator<Add{FeatureName}Input> validator)
    : FluentValidationHandler<Add{FeatureName}Input>(validator)
{
}