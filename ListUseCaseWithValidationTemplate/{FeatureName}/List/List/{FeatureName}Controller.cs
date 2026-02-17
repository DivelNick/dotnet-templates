using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.{FeatureName}.List;

[Route("api/[controller]")]
//[Authorize]
[ApiController]
public class RirController : ControllerBase, ISimpleOutputPort<PagedModel<{FeatureName}Dto>>
{
    private IActionResult _viewModel;

    /// <summary>
    /// Получение списка протоколов
    /// </summary>
    /// <param name="useCase"></param>
    /// <param name="query"></param>
    /// <returns></returns>
    [HttpGet("{FeatureName}/List")]
    public async Task<IActionResult> List([FromServices] I{FeatureName}ListUseCase useCase,
        [FromQuery] {FeatureName}ListQuery query)
    {
        useCase.SetOutputPort(this);

        var input = new {FeatureName}ListInput();
        input.Query = query;

        await useCase.ExecuteAsync(input);

        return _viewModel;
    }


    #region Ports

    [NonAction]
    public void NotFoundError()
    {
        this._viewModel = NotFound();
    }


    [NonAction]
    public void SuccessNoContent()
    {
        this._viewModel = this.NoContent();
    }

    [NonAction]
    public void Success(PagedModel<{FeatureName}Dto> res)
    {
        this._viewModel = this.Ok(new {Success = res});
    }

    [NonAction]
    public void Invalid(Notification notification)
    {
        var problemDetails = new ValidationProblemDetails(notification.ModelState);
        problemDetails.Title = notification.Title;
        this._viewModel = this.BadRequest(problemDetails);
    }

    [NonAction]
    public void Unsuccessfully() => this._viewModel = this.StatusCode(503);

    #endregion
}