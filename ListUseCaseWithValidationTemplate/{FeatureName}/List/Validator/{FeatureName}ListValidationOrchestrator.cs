using FluentValidation;

namespace Application.UseCases.{FeatureName}.List.Validator;

public class {FeatureName}ListValidationOrchestrator : ValidationOrchestratorBase<{FeatureName}ListInput>
{
    public {FeatureName}ListValidationOrchestrator({FeatureName}ListFormatValidationHandler initial,
        {FeatureName}ListValidationHandler handler) : base(initial)
    {
        initial.SetNext(handler);
    }
}

public class {FeatureName}ListFormatValidationHandler(IValidator<{FeatureName}ListInput> validator)
    : FluentValidationHandler<{FeatureName}ListInput>(validator)
{
}

public class {FeatureName}ListValidationHandler(
    IUserService userService) : ValidationHandlerBase<{FeatureName}ListInput>
{
    protected override async Task ProcessValidationAsync({FeatureName}ListInput context)
    {
        var user = await userService.GetCurrentUser();

        if (user == null)
            context.AddValidationError("Пользователь не найден, необходимо авторизоваться");

        if (!user.IsTfomsUser() && user.Organization.OrganizationType.Code != "2")
            context.AddValidationError(
                "Получать информацию могут только пользователи ТФОМС и МО");

        // Если пользователь не СМО не Филиал и не ТФОМС, то надо ограничить код МО
        if (!user.IsTfomsUser() && user.Organization.OrganizationType.Code != "3" &&
            user.Organization.OrganizationType.Code != "4")
            context.Query.Mcod = user.Organization.OrganizationCode;

        //обогащаем контекст
        context.User = user;
    }
}