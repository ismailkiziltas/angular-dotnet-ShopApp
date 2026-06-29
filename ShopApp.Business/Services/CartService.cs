using ShopApp.Core.Entities;
using ShopApp.Core.Interfaces;

namespace ShopApp.Business.Services;

public class CartService
{
    private readonly ICartItemRepository _cartItemRepository;

    public CartService(ICartItemRepository cartItemRepository)
    {
        _cartItemRepository = cartItemRepository;
    }

    public async Task<List<CartItem>> GetCartAsync(string userId)
    {
        return await _cartItemRepository.GetCartByUserIdAsync(userId);
    }

    public async Task AddToCartAsync(string userId, int productId, int quantity)
    {
        var existingItems = await _cartItemRepository.GetCartByUserIdAsync(userId);
        var existingItem = existingItems.FirstOrDefault(c => c.ProductId == productId);

        if (existingItem != null)
        {
            existingItem.Quantity += quantity;
            await _cartItemRepository.UpdateAsync(existingItem);
        }
        else
        {
            var cartItem = new CartItem
            {
                UserId = userId,
                ProductId = productId,
                Quantity = quantity
            };
            await _cartItemRepository.AddAsync(cartItem);
        }
    }

    public async Task RemoveFromCartAsync(int cartItemId)
    {
        await _cartItemRepository.DeleteAsync(cartItemId);
    }

    public async Task ClearCartAsync(string userId)
    {
        await _cartItemRepository.ClearCartAsync(userId);
    }
}