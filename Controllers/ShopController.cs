using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebStore.Core.Services;
using WebStore.Errors;

namespace WebStore.Controllers;
[Authorize]
public class ShopController :BaseApiController
{
    private readonly ShopService _shopService;
    public ShopController(ShopService shopService)
    {
            _shopService = shopService ?? throw new ArgumentNullException(nameof(shopService)); 
    }
    [HttpGet]
    public async Task<IActionResult>Shop()
    {
        try
        {
            var result = await _shopService.ProductsShop();
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(new
            {
                Error = new ApiResponse(400),
                message = ex.Message
            });
        }
    }
}
