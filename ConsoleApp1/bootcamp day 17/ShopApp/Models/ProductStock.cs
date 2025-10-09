namespace ShopApp.Models;

public class ProductStock
{
    public int Id { get; set; }
    public int Quantity { get; set; }

    // Foreign key
    public int ProductId { get; set; }

    // Navigation property (one-to-one)
    public Product? Product { get; set; }
}