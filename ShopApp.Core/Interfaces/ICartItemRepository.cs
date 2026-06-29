using ShopApp.Core.Entities;

namespace ShopApp.Core.Interfaces;

public interface ICartItemRepository : IRepository<CartItem>
{
    Task<List<CartItem>> GetCartByUserIdAsync(string userId);
    Task ClearCartAsync(string userId);
    Task UpdateProductStockAsync(Product product);
}