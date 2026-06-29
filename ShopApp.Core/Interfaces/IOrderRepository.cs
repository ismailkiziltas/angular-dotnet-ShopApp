using ShopApp.Core.Entities;

namespace ShopApp.Core.Interfaces;

public interface IOrderRepository : IRepository<Order>
{
    Task<List<Order>> GetByUserIdAsync(string userId);
    Task<Order?> GetOrderWithItemsAsync(int orderId);
}