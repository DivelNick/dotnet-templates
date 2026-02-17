using System.Linq;
using System.Threading.Tasks;

namespace Application.UseCases.{FeatureName}.List;

/* Добавление структуры для Startup
    //list
    services.AddScoped<IValidator<{FeatureName}ListInput>, {FeatureName}ListFieldsValidator>();
    services.AddScoped<{FeatureName}ListFormatValidationHandler>();
    services.AddScoped<{FeatureName}ListValidationHandler>();
    services.AddScoped<IValidationOrchestrator<{FeatureName}ListInput>, {FeatureName}ListValidationOrchestrator>();
    services.AddScoped<I{FeatureName}ListUseCase, {FeatureName}ListUseCase>();
*/

public interface I{FeatureName}ListUseCase : ISimpleUseCase<ISimpleOutputPort<PagedModel<{FeatureName}Dto>>, {FeatureName}ListInput>
{
}

public class {FeatureName}ListUseCase : SimpleUseCase<ISimpleOutputPort<PagedModel<{FeatureName}Dto>>, {FeatureName}ListInput>,
    I{FeatureName}ListUseCase
{
    private readonly IRirRepository _repo;

    public {FeatureName}ListUseCase(IValidationOrchestrator<{FeatureName}ListInput> validator
        , IRirRepository repo) : base(validator)
    {
        _repo = repo;
    }

    public override async Task ExecuteAfterInputModelValidation({FeatureName}ListInput input)
    {
        var res = await _repo.ListBySpecAsync(input.Query);

        var result = new PagedModel<{FeatureName}Dto>(res.list.Select(i => new {FeatureName}Dto(i)).ToList(), res.count,
            input.Query.PageNumber, input.Query.PageSize);

        _outputPort.Success(result);
    }
}