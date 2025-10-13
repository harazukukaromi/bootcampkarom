using PenjualanBarangApi.Models;

namespace PenjualanBarangApi.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product?> GetByIdAsync(int id);
        Task AddAsync(Product product);
        Task UpdateAsync(Product product);
        Task DeleteAsync(Product product);
        Task SaveAsync();
        Task<bool> ExistsByNameAsync(string name);
    }
}