namespace WebApi.Controllers.{FeatureName}.Get;

[Route("api/[controller]")]
//[Authorize]
[ApiController]
public class {FeatureName}Controller : ControllerBase, ISimpleOutputPort<Get{FeatureName}ViewModel>
{
    private IActionResult _viewModel;


    /// <summary>
    /// Получение записи {FeatureName} 
    /// </summary>
    /// <param name="useCase"></param>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet("{FeatureName}")]
    public async Task<IActionResult> List([FromServices] IGet{FeatureName}UseCase useCase,
        [FromQuery] Guid Id)
    {
        useCase.SetOutputPort(this);

        var input = new Get{FeatureName}Input();
        input.Id = Id;

        await useCase.ExecuteAsync(input);

        return _viewModel;
    }


    #region ports

    [NonAction]
    public void NotFoundError()
    {
        this._viewModel = NotFound();
    }


    [NonAction]
    public void Success(Get{FeatureName}ViewModel ob)
    {
        this._viewModel = this.Ok(new { Success = ob });
    }
    

    [NonAction]
    public void SuccessNoContent()
    {
        this._viewModel = this.NoContent();
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