using ShopApp.Core.Entities;
using ShopApp.Core.Interfaces;

namespace ShopApp.Business.Services;

public class OrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly ICartItemRepository _cartItemRepository;

    public OrderService(IOrderRepository orderRepository, ICartItemRepository cartItemRepository)
    {
        _orderRepository = orderRepository;
        _cartItemRepository = cartItemRepository;
    }

    public async Task<List<Order>> GetUserOrdersAsync(string userId)
    {
        return await _orderRepository.GetByUserIdAsync(userId);
    }

    public async Task<Order?> GetOrderWithItemsAsync(int orderId)
    {
        return await _orderRepository.GetOrderWithItemsAsync(orderId);
    }

    public async Task<Order> CreateOrderFromCartAsync(string userId, string address)
    {
        var cartItems = await _cartItemRepository.GetCartByUserIdAsync(userId);

        if (!cartItems.Any())
            throw new Exception("Sepet boş!");

        // Stok kontrolü
        foreach (var item in cartItems)
        {
            if (item.Product.Stock < item.Quantity)
                throw new Exception($"{item.Product.Name} için yeterli stok yok! Mevcut stok: {item.Product.Stock}");
        }

        var order = new Order
        {
            UserId = userId,
            Address = address,
            Status = OrderStatus.Pending,
            OrderItems = cartItems.Select(ci => new OrderItem
            {
                ProductId = ci.ProductId,
                Quantity = ci.Quantity,
                UnitPrice = ci.Product.Price
            }).ToList(),
            TotalPrice = cartItems.Sum(ci => ci.Product.Price * ci.Quantity)
        };

        await _orderRepository.AddAsync(order);

        // Stok düş
        foreach (var item in cartItems)
        {
            item.Product.Stock -= item.Quantity;
            await _cartItemRepository.UpdateProductStockAsync(item.Product);
        }

        await _cartItemRepository.ClearCartAsync(userId);

        return order;
    }
}