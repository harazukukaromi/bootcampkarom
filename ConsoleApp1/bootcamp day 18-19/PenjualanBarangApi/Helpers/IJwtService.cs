using PenjualanBarangApi.Models;

namespace PenjualanBarangApi.Helpers
{
    public interface IJwtService
    {
        string GenerateToken(User user);
    }
}
