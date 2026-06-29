namespace ShopApp.Core.Entities;

public class CartItem : BaseEntity
{
    public int Quantity { get; set; }

    // Foreign Keys
    public int ProductId { get; set; }
    public string UserId { get; set; } = string.Empty;

    // Navigation Property
    public Product Product { get; set; } = null!;
}