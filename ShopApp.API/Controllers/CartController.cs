using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopApp.Business.Services;

namespace ShopApp.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class CartController : ControllerBase
{
    private readonly CartService _cartService;

    public CartController(CartService cartService)
    {
        _cartService = cartService;
    }

    private string GetUserId() =>
        User.FindFirstValue(ClaimTypes.NameIdentifier)!;

    [HttpGet]
    public async Task<IActionResult> GetCart()
    {
        var cart = await _cartService.GetCartAsync(GetUserId());
        return Ok(cart);
    }

    [HttpPost]
    public async Task<IActionResult> AddToCart(int productId, int quantity)
    {
        await _cartService.AddToCartAsync(GetUserId(), productId, quantity);
        return Ok();
    }

    [HttpDelete("{cartItemId}")]
    public async Task<IActionResult> RemoveFromCart(int cartItemId)
    {
        await _cartService.RemoveFromCartAsync(cartItemId);
        return Ok();
    }

    [HttpDelete("clear")]
    public async Task<IActionResult> ClearCart()
    {
        await _cartService.ClearCartAsync(GetUserId());
        return Ok();
    }
}