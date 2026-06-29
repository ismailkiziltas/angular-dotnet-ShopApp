namespace ShopApp.Core.Entities;

public class OrderItem : BaseEntity
{
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }

    // Foreign Keys
    public int ProductId { get; set; }
    public int OrderId { get; set; }

    // Navigation Properties
    public Product Product { get; set; } = null!;
    public Order Order { get; set; } = null!;
}