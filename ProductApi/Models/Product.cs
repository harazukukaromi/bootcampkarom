namespace ProductApi.Models
{
    public class Product
    {
        public int Id { get; set; }           // ID unik produk
        public string Name { get; set; } = ""; // Nama produk
        public decimal Price { get; set; }     // Harga produk
    }
}