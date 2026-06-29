using ShopApp.Core.Entities;
using ShopApp.Core.Interfaces;

namespace ShopApp.Business.Services;

public class ProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<List<Product>> GetAllProductsAsync()
    {
        return await _productRepository.GetAllAsync();
    }

    public async Task<Product?> GetProductByIdAsync(int id)
    {
        return await _productRepository.GetByIdAsync(id);
    }

    public async Task<List<Product>> GetByCategoryAsync(int categoryId)
    {
        return await _productRepository.GetByCategoryAsync(categoryId);
    }

    public async Task<List<Product>> SearchProductsAsync(string keyword)
    {
        return await _productRepository.SearchAsync(keyword);
    }

    public async Task AddProductAsync(Product product)
    {
        await _productRepository.AddAsync(product);
    }

    public async Task UpdateProductAsync(Product product)
    {
        product.UpdatedAt = DateTime.UtcNow;
        await _productRepository.UpdateAsync(product);
    }

    public async Task DeleteProductAsync(int id)
    {
        await _productRepository.DeleteAsync(id);
    }
}