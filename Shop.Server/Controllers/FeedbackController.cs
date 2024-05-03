

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
[ApiController]
[Route("api/[controller]")]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class FeedbackController : ControllerBase
{
    private readonly IFeedbackService _feedbackService;

    public FeedbackController(IFeedbackService feedbackService)
    {
        _feedbackService = feedbackService;
    }
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] string prodId)
    {
        try
        {
            var res = await _feedbackService.GetProductFeedbacks(prodId);
            if (!res.IsSucceed) return BadRequest(res);
            return Ok(res);
        }
        catch (Exception ex)
        {
            var problem = new ProblemDetails();
            problem.Detail = ex.Message;
            problem.Status = StatusCodes.Status500InternalServerError;
            return StatusCode(StatusCodes.Status500InternalServerError, problem);
        }
    }
    [HttpPost]
    public async Task<IActionResult> Add([FromQuery] string productId, [FromQuery] float rate, [FromQuery] string comment)
    {
        try
        {
            var res = await _feedbackService.AddProductFeedbackAsync(productId, rate, comment);
            if (!res.IsSucceed) return BadRequest(res);
            return Ok(res);
        }
        catch (Exception ex)
        {
            var problem = new ProblemDetails();
            problem.Detail = ex.Message;
            problem.Status = StatusCodes.Status500InternalServerError;
            return StatusCode(StatusCodes.Status500InternalServerError, problem);
        }
    }
    [HttpDelete]

    public async Task<IActionResult> Delete(Guid feedbackId)
    {
        try
        {
            var res = await _feedbackService.DeleteProductFeedbackAsync(feedbackId);
            if (!res.IsSucceed) return BadRequest(res);
            return Ok(res);
        }
        catch (Exception ex)
        {
            var problem = new ProblemDetails();
            problem.Detail = ex.Message;
            problem.Status = StatusCodes.Status500InternalServerError;
            return StatusCode(StatusCodes.Status500InternalServerError, problem);
        }
    }
    [HttpPut]
    public async Task<IActionResult> Update([FromQuery] Guid feedbackId, [FromQuery] string newComment, [FromQuery] float newRate)
    {
        try
        {
            var res = await _feedbackService.UpdateProductFeedbackAsync(feedbackId, newComment, newRate);
            if (!res.IsSucceed) return BadRequest(res);
            return Ok(res);
        }
        catch (Exception ex)
        {
            var problem = new ProblemDetails();
            problem.Detail = ex.Message;
            problem.Status = StatusCodes.Status500InternalServerError;
            return StatusCode(StatusCodes.Status500InternalServerError, problem);
        }
    }
}