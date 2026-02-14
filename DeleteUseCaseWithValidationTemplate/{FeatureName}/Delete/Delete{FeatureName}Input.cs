namespace Application.UseCases.{FeatureName}.Delete;

public class Delete{FeatureName}Input : ValidationContextInput
{
    public Guid  Id { get; set; }

    public {FeatureName} Model { get; set; }
}