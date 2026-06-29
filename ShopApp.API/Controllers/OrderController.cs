using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopApp.Business.Services;

namespace ShopApp.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class OrderController : ControllerBase
{
    private readonly OrderService _orderService;

    public OrderController(OrderService orderService)
    {
        _orderService = orderService;
    }

    private string GetUserId() =>
        User.FindFirstValue(ClaimTypes.NameIdentifier)!;

    [HttpGet]
    public async Task<IActionResult> GetMyOrders()
    {
        var orders = await _orderService.GetUserOrdersAsync(GetUserId());
        return Ok(orders);
    }

    [HttpGet("{orderId}")]
    public async Task<IActionResult> GetOrderDetail(int orderId)
    {
        var order = await _orderService.GetOrderWithItemsAsync(orderId);
        if (order == null) return NotFound();
        return Ok(order);
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrder([FromBody] CreateOrderDto model)
    {
        try
        {
            var order = await _orderService.CreateOrderFromCartAsync(GetUserId(), model.Address);
            return Ok(order);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}

public class CreateOrderDto
{
    public string Address { get; set; } = string.Empty;
}