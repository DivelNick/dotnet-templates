namespace Application.UseCases.{FeatureName}.Get;

public class Get{FeatureName}Input : ValidationContextInput
{
    public Guid  Id { get; set; }

    public {FeatureName} DomainModel { get; set; }
}