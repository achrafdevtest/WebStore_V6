using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebStore.Core.Models;
using WebStore.Core.Services;

namespace WebStore.Controllers;
[Authorize]
public class OrdersControllers : BaseApiController
{
    private readonly OrderService _orderService;
    public OrdersControllers(OrderService orderService)
    => _orderService = orderService ?? throw new ArgumentNullException(nameof(orderService));

    [HttpPost("add")]
    public async Task<IActionResult> CreateOrder([FromBody] NewOrder newOrder)
    {
        try
        {
            var num = await _orderService.CreateOrder(newOrder);
            return Ok(num);
        }
        catch (Exception ex)
        {
            return BadRequest(new
            {
                message = ex.Message
            });
        }
    }
}

