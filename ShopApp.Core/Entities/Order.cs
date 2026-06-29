namespace ShopApp.Core.Entities;

public enum OrderStatus
{
    Pending, // Beklemede
    Confirmed, // Onaylandı
    Shipped, // Kargoya verildi
    Delivered, // Teslim edildi
    Cancelled // İptal edildi
}

public class Order : BaseEntity
{
    public string UserId { get; set; } = string.Empty;
    public DateTime OrderDate { get; set; } = DateTime.UtcNow;
    public decimal TotalPrice { get; set; }
    public OrderStatus Status { get; set; } = OrderStatus.Pending;
    public string Address { get; set; } = string.Empty;

    // Navigation Property
    public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}