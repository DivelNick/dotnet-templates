using FluentValidation;

namespace Application.UseCases.{FeatureName}.Get.Validator;

public class Get{FeatureName}ValidationOrchestrator : ValidationOrchestratorBase<Get{FeatureName}Input>
{
    public Get{FeatureName}ValidationOrchestrator(Get{FeatureName}FormatValidationHandler initial, 
    Get{FeatureName}ValidationHandler handler) : base(initial)
    {
        initial.SetNext(handler);
    }
}

public class Get{FeatureName}FormatValidationHandler(IValidator<Get{FeatureName}Input> validator)
    : FluentValidationHandler<Get{FeatureName}Input>(validator)
{
}

public class Get{FeatureName}ValidationHandler()
    : ValidationHandlerBase<Get{FeatureName}Input>
{
    // проверяем есть ли запись и обогащаем контекст
    protected override async Task ProcessValidationAsync(Get{FeatureName}Input context)
    {
    }
}