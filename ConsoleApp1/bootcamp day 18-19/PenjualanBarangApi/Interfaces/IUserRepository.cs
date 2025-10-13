using PenjualanBarangApi.Models;
using System.Threading.Tasks;

namespace PenjualanBarangApi.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetByUsernameAsync(string username);
        Task AddUserAsync(User user);
        Task SaveAsync();
    }
}