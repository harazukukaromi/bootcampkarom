namespace PenjualanBarangApi.DTOs
{
    public class ProductUpdateDTO
    {
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Stock { get; set; }
    }
}