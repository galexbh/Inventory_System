using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Inventory_System.Models;

namespace Inventory_System.Context
{
    public class InventoryContext : DbContext
    {
        public InventoryContext(DbContextOptions<InventoryContext> options) : base(options) { }

        public DbSet<Role> Roles { get; init; }
        public DbSet<Supplier> Suppliers { get; init; }
        public DbSet<User> Users { get; init; }
        public DbSet<Winery> Winerys { get; init; }
        public DbSet<BranchOffice> BranchOffices { get; init; }
        public DbSet<Stock> Stocks { get; init; }
        public DbSet<Product> Products { get; init; }


    }
}