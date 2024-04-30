

// using Microsoft.AspNetCore.Authentication.JwtBearer;
// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Mvc;
// using Shop.Server.ServicesContracts;
// [ApiController]
// [Route("api/[controller]")]

// public class ShoppingCartController : ControllerBase
// {
//     private readonly IShoppingCartService _shoppingCartService;
//     public ShoppingCartController(IShoppingCartService shoppingCartService)
//     {
//         _shoppingCartService = shoppingCartService;
//     }
//     [HttpGet]
//     [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
//     public async Task<IActionResult> Get()
//     {
//         var cart = await _shoppingCartService.GetShoppingCartAsync();

//         return Ok(cart);
//     }
// }