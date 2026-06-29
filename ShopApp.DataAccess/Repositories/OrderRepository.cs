using Microsoft.EntityFrameworkCore;
using ShopApp.Core.Entities;
using ShopApp.Core.Interfaces;
using ShopApp.DataAccess.Context;

namespace ShopApp.DataAccess.Repositories;

public class OrderRepository : Repository<Order>, IOrderRepository
{
    public OrderRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<List<Order>> GetByUserIdAsync(string userId)
    {
        return await _dbSet
            .Where(o => o.UserId == userId && !o.IsDeleted)
            .Include(o => o.OrderItems)
            .ThenInclude(oi => oi.Product)
            .ToListAsync();
    }

    public async Task<Order?> GetOrderWithItemsAsync(int orderId)
    {
        return await _dbSet
            .Include(o => o.OrderItems)
            .ThenInclude(oi => oi.Product)
            .FirstOrDefaultAsync(o => o.Id == orderId && !o.IsDeleted);
    }
}