using FluentValidation;

namespace Application.UseCases.{FeatureName}.Update.Validator;

public class Delete{FeatureName}ValidationOrchestrator : ValidationOrchestratorBase<Delete{FeatureName}Input>
{
    public Delete{FeatureName}ValidationOrchestrator(Delete{FeatureName}FormatValidationHandler initial, 
    Delete{FeatureName}ValidationHandler handler) : base(initial)
    {
        initial.SetNext(handler);
    }
}

public class Delete{FeatureName}FormatValidationHandler(IValidator<Delete{FeatureName}Input> validator)
    : FluentValidationHandler<Delete{FeatureName}Input>(validator)
{
}

public class Delete{FeatureName}ValidationHandler()
    : ValidationHandlerBase<Delete{FeatureName}Input>
{
    // проверяем есть ли запись и обогащаем контекст
    protected override async Task ProcessValidationAsync(Delete{FeatureName}Input context)
    {
        var model = await repo.GetFirst<{FeatureName}>(c => c.Id == context.Id);

        if (model == null)
        {
            context.AddError("Ошибка валидации", $"Запись с Id {context.Id} не найдена");
            return;
        }

        context.Model = model;   
    }
}