using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inventory_System.Models;

namespace Inventory_System.Data.Interfaces
{
    public interface IProductRepository : IGenericRepository
    {
        Task<IEnumerable<Product>> GetProductsAsync();
        Task<Product> GetProductByIdAsync(int id);
        Task<Product> GetProductByBrandAsync(string brand);
    }
}