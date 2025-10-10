namespace PenjualanBarangApi.Models
{
    public class Product
    {
        public int Id { get; set; }              // ID barang
        public string Name { get; set; }         // Nama barang
        public decimal Price { get; set; }       // Harga barang
        public int Stock { get; set; }           // Jumlah stok
    }
}
