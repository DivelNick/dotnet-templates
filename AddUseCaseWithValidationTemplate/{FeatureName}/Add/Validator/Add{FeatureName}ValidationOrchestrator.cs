namespace Application.UseCases.{FeatureName}.Add.Validator;

public class Add{FeatureName}ValidationOrchestrator : ValidationOrchestratorBase<Add{FeatureName}Input>
{
public Add{FeatureName}ValidationOrchestrator(Add{FeatureName}FormatValidationHandler initial, 
    Add{FeatureName}ValidationHandler handler) : base(initial)
{
    initial.SetNext(handler);
}
}

public class Add{FeatureName}FormatValidationHandler(IValidator<Add{FeatureName}Input> validator)
    : FluentValidationHandler<Add{FeatureName}Input>(validator)
{
}

public class Add{FeatureName}ValidationHandler()
    : ValidationHandlerBase<Add{FeatureName}Input>
{
// проверяем данные с БД и обогащаем контекст
protected override async Task ProcessValidationAsync(Add{FeatureName}Input context)
{
}
}