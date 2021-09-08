using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inventory_System.Context;
using Inventory_System.Data.Interfaces;
using Inventory_System.Models;

using Microsoft.EntityFrameworkCore;

namespace Inventory_System.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly InventoryContext _context;

        public AuthRepository(InventoryContext context)
        {
            this._context = context;
        }

        public async Task<User> Login(string email, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.email == email);
            if (user == null)
                return null;
            if (!VerifyPasswordHash(password, user.passwordHash, user.passwordSalt))
                return null;

            return user;
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i]) return false;
                }
            }
            return true;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public async Task<User> Register(User user, string password)
        {
            byte[] passwordHash;
            byte[] passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);
            user.passwordHash = passwordHash;
            user.passwordSalt = passwordSalt;

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<bool> UserExists(string email)
        {
            if (await _context.Users.AnyAsync(x => x.email == email))
                return true;

            return false;
        }
    }
}