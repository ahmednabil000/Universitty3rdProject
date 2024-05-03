

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.Server.ServicesContracts;
[ApiController]
[Route("api/[controller]")]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class ShoppingCartController : ControllerBase
{
    private readonly IShoppingCartService _shoppingCartService;
    public ShoppingCartController(IShoppingCartService shoppingCartService)
    {
        _shoppingCartService = shoppingCartService;
    }
    [HttpGet]

    public async Task<IActionResult> Get()
    {
        var cart = await _shoppingCartService.GetShoppingCartAsync();

        return Ok(cart);
    }
    [HttpPost]
    [Route("UpdateCartItemQuantity")]

    public async Task<IActionResult> UpdateCartItemQuantity([FromQuery] Guid cartItemId, [FromQuery] int newQuantity)
    {
        try
        {
            var resault = await _shoppingCartService.UpdateItemQuantityAsync(cartItemId, newQuantity);

            if (!resault.IsSucceed) return BadRequest(resault);

            return Ok(resault);
        }
        catch (Exception ex)
        {
            var problem = new ProblemDetails();
            problem.Detail = ex.Message;
            return StatusCode(StatusCodes.Status500InternalServerError, problem);
        }
    }
    [HttpPost]
    [Route("AddShoppingCartItem")]
    public async Task<IActionResult> AddShoppingCartItem([FromQuery] string prodId, [FromQuery] int quantity)
    {
        try
        {
            var resault = await _shoppingCartService.AddShoppingCartItemAsync(prodId, quantity);
            if (!resault.IsSucceed) return BadRequest(resault);

            return Ok(resault);
        }
        catch (Exception ex)
        {
            var problem = new ProblemDetails();
            problem.Detail = ex.Message;
            return StatusCode(StatusCodes.Status500InternalServerError, problem);
        }
    }
    [HttpPut]
    [Route("ClearShoppingCart")]
    public async Task<IActionResult> ClearShoppingCart()
    {
        try
        {
            var resault = await _shoppingCartService.ClearShoppingCartAsync();
            if (!resault.IsSucceed) return BadRequest(resault);

            return Ok(resault);
        }
        catch (Exception ex)
        {
            var problem = new ProblemDetails();
            problem.Detail = ex.Message;
            return StatusCode(StatusCodes.Status500InternalServerError, problem);
        }
    }
}