using System;
using Microsoft.EntityFrameworkCore;

namespace Application.UseCases.{FeatureName}.List;

public class {FeatureName}ListQuery : SpecificationPagedQuery<{FeatureName}>
{

    protected override void SetupSearchSpecification(SearchSpecification<{FeatureName}> spec)
    {
    }
}