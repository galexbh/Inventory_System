using Inventory_System.Models;

namespace Inventory_System.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}