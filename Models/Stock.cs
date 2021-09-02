using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory_System.Models
{
    public record Stock
    {
        public int StockId { get; init; }
        public int ProductId { get; init; }
        public Winery Winery { get; init; }
        public int quantity { get; init; }

        public Product Product { get; init; }
    }
}