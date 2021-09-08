using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inventory_System.Context;
using Inventory_System.Data.Interfaces;
using Inventory_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Inventory_System
{
    public class UserRepository : IUserRepository
    {
        private readonly InventoryContext _context;

        public UserRepository(InventoryContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.UserId == id);
        }

        public async Task<User> GetUserByNameAsync(string name)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.name == name);
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
    }
}