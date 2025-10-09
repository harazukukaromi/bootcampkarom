namespace ShopApp.Models
{
    public class Supplier
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // relationship many to many
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}

