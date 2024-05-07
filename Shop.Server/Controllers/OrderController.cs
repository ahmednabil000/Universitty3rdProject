

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.Server.ServicesContracts;


[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    private readonly IOrderService _orderService;
    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }
    [HttpPost]
    [Route("CreateOrder")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public async Task<IActionResult> CreateOrder([FromQuery] OrderDTO orderDTO)
    {
        try
        {
            var resault = await _orderService.CreateOrderAsync(orderDTO);
            if (!resault.IsSucceed) return BadRequest(resault);
            return Ok("Your order has been created successfully");
        }
        catch (Exception ex)
        {
            var problem = new ProblemDetails();
            problem.Detail = ex.Message;
            problem.Status = StatusCodes.Status500InternalServerError;
            return StatusCode(StatusCodes.Status500InternalServerError, problem);
        }
    }
    [HttpGet]
    [Route("GetOrderDetails")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public async Task<IActionResult> GetOrderDetails([FromQuery] Guid orderId)
    {
        try
        {
            var resault = await _orderService.GetOrderDetails(orderId);
            if (resault.IsSucceed) return Ok(resault);

            return BadRequest(resault);
        }
        catch (Exception ex)
        {
            var problem = new ProblemDetails();
            problem.Detail = ex.Message;
            problem.Status = StatusCodes.Status500InternalServerError;
            return StatusCode(StatusCodes.Status500InternalServerError, problem);
        }
    }
    [HttpGet]
    [Route("GetOrders")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public async Task<IActionResult> GetOrders()
    {
        try
        {
            var resault = await _orderService.GetOrders();
            if (resault.IsSucceed) return Ok(resault);

            return BadRequest(resault);
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
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public async Task<IActionResult> RemoveOrder(Guid orderId)
    {
        try
        {
            var resault = await _orderService.RemoveOrder(orderId);
            if (resault.IsSucceed) return Ok(resault);

            return BadRequest(resault);

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
    [Route("ConfirmOrderAsCompleted")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = $"{ApplicationRoles.Admin}")]
    public async Task<IActionResult> ConfirmOrderAsCompleted(Guid orderId)
    {
        try
        {
            var resault = await _orderService.ConfirmOrderAsCompletedAsync(orderId);
            if (resault.IsSucceed) return Ok(resault);

            return BadRequest(resault);

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
    [Route("ConfirmOrderAsDeliverd")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = $"{ApplicationRoles.DeliveryMan}")]
    public async Task<IActionResult> ConfirmOrderAsDeliverd(Guid orderId)
    {
        try
        {
            var resault = await _orderService.ConfirmOrderAsDeliverdAsync(orderId);
            if (resault.IsSucceed) return Ok(resault);

            return BadRequest(resault);

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