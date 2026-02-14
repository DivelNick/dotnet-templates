namespace WebApi.Controllers.{FeatureName}.Delete;

[Microsoft.AspNetCore.Components.Route("api/[controller]")]
//[Authorize]
[ApiController]
public class {FeatureName}Controller : ControllerBase, ISimpleOutputPort<bool>
{
    private IActionResult _viewModel;


    /// <summary>
    /// Получение записи {FeatureName} 
    /// </summary>
    /// <param name="useCase"></param>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpDelete("{FeatureName}/Delete")]
    public async Task<IActionResult> List([FromServices] IDelete{FeatureName}UseCase useCase,
        [FromQuery] Guid Id)
    {
        useCase.SetOutputPort(this);

        var input = new Delete{FeatureName}Input();
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
    public void Success(bool ob)
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