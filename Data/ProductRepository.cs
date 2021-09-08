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
    public class ProductRepository : IProductRepository
    {
        private readonly InventoryContext _context;

        public ProductRepository(InventoryContext context)
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

        public async Task<Product> GetProductByBrandAsync(string brand)
        {
            return await _context.Products.FirstOrDefaultAsync(u => u.brand == brand);
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _context.Products.FirstOrDefaultAsync(u => u.ProductId == id);
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _context.Products.ToListAsync();
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