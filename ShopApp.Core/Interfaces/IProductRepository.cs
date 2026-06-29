using ShopApp.Core.Entities;

namespace ShopApp.Core.Interfaces;

public interface IProductRepository : IRepository<Product>
{
    Task<List<Product>> GetByCategoryAsync(int categoryId);
    Task<List<Product>> SearchAsync(string query);
}