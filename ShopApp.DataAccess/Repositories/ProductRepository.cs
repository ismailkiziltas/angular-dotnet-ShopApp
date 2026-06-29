using Microsoft.EntityFrameworkCore;
using ShopApp.Core.Interfaces;
using ShopApp.Core.Entities;
using ShopApp.DataAccess.Context;

namespace ShopApp.DataAccess.Repositories;

public class ProductRepository : Repository<Product>, IProductRepository
{
    public ProductRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<List<Product>> GetByCategoryAsync(int categoryId)
    {
        return await _dbSet.Where(p => p.CategoryId == categoryId && !p.IsDeleted).ToListAsync();
    }

    public async Task<List<Product>> SearchAsync(string keyword)
    {
        return await _dbSet
            .Where(p => p.Name.Contains(keyword) && !p.IsDeleted)
            .ToListAsync();
    }
}