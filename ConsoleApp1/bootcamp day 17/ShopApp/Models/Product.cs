namespace ShopApp.Models
{
    public class Product
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public decimal Price { get; set; }

        // One-to-Many
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        // Many-to-Many
        public ICollection<Supplier> Suppliers { get; set; } = new List<Supplier>();

        public ProductStock? ProductStock { get; set; }

        // One-to-One
        public ProductDetail ProductDetail { get; set; }
    }
}
