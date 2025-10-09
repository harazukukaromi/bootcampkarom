namespace ShopApp.Models;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; } = "";

    // Relasi One-to-Many
    public List<Product> Products { get; set; } = new();
}