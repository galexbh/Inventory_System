using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Inventory_System.Models;

namespace Inventory_System.Data.Interfaces
{
    public interface IAuthRepository
    {
        Task<User> Register(User user, string password);
        Task<User> Login(string email, string password);
        Task<bool> UserExists(string email);
    }
}