using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inventory_System.Models;

namespace Inventory_System.Data.Interfaces
{
    public interface IUserRepository : IGenericRepository
    {
        Task<IEnumerable<User>> GetUsersAsync();
        Task<User> GetUserByIdAsync(int id);
        Task<User> GetUserByNameAsync(string name);
    }
}