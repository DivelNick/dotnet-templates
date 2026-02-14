using FluentValidation;

namespace Application.UseCases.{FeatureName}.Update.Validator;

public class Update{FeatureName}ValidationOrchestrator : ValidationOrchestratorBase<Update{FeatureName}Input>
{
public Update{FeatureName}ValidationOrchestrator(Update{FeatureName}FormatValidationHandler initial, 
    Update{FeatureName}ValidationHandler handler) : base(initial)
{
    initial.SetNext(handler);
}
}

public class Update{FeatureName}FormatValidationHandler(IValidator<Update{FeatureName}Input> validator)
    : FluentValidationHandler<Update{FeatureName}Input>(validator)
{
}

public class Update{FeatureName}ValidationHandler()
    : ValidationHandlerBase<Update{FeatureName}Input>
{
// проверяем есть ли запись и обогащаем контекст
protected override async Task ProcessValidationAsync(Update{FeatureName}Input context)
{
}
}