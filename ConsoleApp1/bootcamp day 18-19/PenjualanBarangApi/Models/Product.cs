namespace PenjualanBarangApi.Models
{
    public class Product
    {
        public int Id { get; set; }              // ID barang
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }        // Harga barang
        public int Stock { get; set; }           // Jumlah stok
    }
}
