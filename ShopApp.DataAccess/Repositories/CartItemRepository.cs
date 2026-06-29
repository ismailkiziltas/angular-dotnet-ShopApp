using Microsoft.EntityFrameworkCore;
using ShopApp.Core.Entities;
using ShopApp.Core.Interfaces;
using ShopApp.DataAccess.Context;

namespace ShopApp.DataAccess.Repositories;

public class CartItemRepository : Repository<CartItem>, ICartItemRepository
{
    public CartItemRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<List<CartItem>> GetCartByUserIdAsync(string userId)
    {
        return await _dbSet
            .Where(c => c.UserId == userId && !c.IsDeleted)
            .Include(c => c.Product)
            .ToListAsync();
    }

    public async Task ClearCartAsync(string userId)
    {
        var items = await _dbSet
            .Where(c => c.UserId == userId)
            .ToListAsync();
        
        _dbSet.RemoveRange(items);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateProductStockAsync(Product product)
    {
        _context.Set<Product>().Update(product);
        await _context.SaveChangesAsync();
    }
}