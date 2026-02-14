namespace Application.UseCases.{FeatureName}.Delete;

/* Добавление структуры для Startup    
    //delete 
    services.AddScoped<IValidator<Delete{FeatureName}Input>, Delete{FeatureName}FieldsValidator>();
    services.AddScoped<Delete{FeatureName}FormatValidationHandler>();
    services.AddScoped<Delete{FeatureName}ValidationHandler>();
    services.AddScoped<IValidationOrchestrator<Delete{FeatureName}Input>, Delete{FeatureName}ValidationOrchestrator>();
    services.AddScoped<IDelete{FeatureName}UseCase, Delete{FeatureName}UseCase>();
*/
public interface IDelete{FeatureName}UseCase : ISimpleUseCase<ISimpleOutputPort<bool>, Delete{FeatureName}Input>
{
}

public class Delete{FeatureName}UseCase : SimpleUseCase<ISimpleOutputPort<bool>, Delete{FeatureName}Input>, IDelete{FeatureName}UseCase
{
    private readonly IRirRepository _repo;
    private readonly IUnitOfWork _unitOfWork;

    public Delete{FeatureName}UseCase(
        IValidationOrchestrator<Delete{FeatureName}Input> validator,
        IRirRepository repo,
        IUnitOfWork unitOfWork
        ) : base(validator)
    {
        _repo = repo;
        _unitOfWork = unitOfWork;
    }

    public override async Task ExecuteAfterInputModelValidation(Delete{FeatureName}Input input)
    {
        await _repo.Remove<{FeatureName}>(m => m.Id == input.Id);
        var af = await _unitOfWork.Save();
        if (af > 0)
        {
            _outputPort.Success(true);
            return;
        }

        _outputPort.Unsuccessfully();
    }
}