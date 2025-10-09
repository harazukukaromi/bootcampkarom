namespace ShopApp.Models
{
    public class ProductDetail
    {
        public int Id { get; set; }
        public required string Description { get; set; }
        public required string SKU { get; set; }

        // One-to-One
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}

