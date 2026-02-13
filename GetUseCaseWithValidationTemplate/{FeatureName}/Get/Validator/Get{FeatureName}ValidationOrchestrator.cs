namespace Application.UseCases.{FeatureName}.Get.Validator;

public class Get{FeatureName}ValidationOrchestrator(IValidationHandler<Get{FeatureName}Input> validationChain)
    : ValidationOrchestratorBase<Get{FeatureName}Input>(validationChain)
{
}

public class Get{FeatureName}FormatValidationHandler(IValidator<Get{FeatureName}Input> validator)
    : FluentValidationHandler<Get{FeatureName}Input>(validator)
{
}