namespace Application.UseCases.{FeatureName}.Add;

/* Добавление структуры для Startup
    //add
    services.AddScoped<IValidator<Add{FeatureName}Input>, Add{FeatureName}FieldsValidator>();
    services.AddScoped<Add{FeatureName}FormatValidationHandler>();
    services.AddScoped<Add{FeatureName}ValidationHandler>();
    services.AddScoped<IValidationOrchestrator<Add{FeatureName}Input>, Add{FeatureName}ValidationOrchestrator>();
    services.AddScoped<IAdd{FeatureName}UseCase, Add{FeatureName}UseCase>();
*/

public interface IAdd{FeatureName}UseCase : ISimpleUseCase<ISimpleOutputPort<bool>, Add{FeatureName}Input>
{
}

public class Add{FeatureName}UseCase : SimpleUseCase<ISimpleOutputPort<bool>, Add{FeatureName}Input>, IAdd{FeatureName}UseCase
{

    private readonly IRirRepository _repo;
    private readonly IUnitOfWork _unitOfWork;

    public Add{FeatureName}UseCase(IValidationOrchestrator<Add{FeatureName}Input> validator,
        IRirRepository repo, IUnitOfWork unitOfWork
    ) : base(validator)
    {
        _repo = repo;
        _unitOfWork = unitOfWork;
    }

    public override async Task ExecuteAfterInputModelValidation(Add{FeatureName}Input input)
    {
        var p = new {FeatureName}();
        
        await _repo.Add(p);
        int af = await _unitOfWork.Save();

        if (af > 0) _outputPort.Success(true);
        else _outputPort.Unsuccessfully();
    }
}