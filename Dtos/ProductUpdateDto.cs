using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inventory_System.Models;

namespace Inventory_System.Dtos
{
    public class ProductUpdateDto
    {
        public int ProductId { get; init; }

        public Supplier Supplier { get; init; }

        public string brand { get; init; }

        public string presentation { get; init; }

        public string description { get; init; }

        public string internalCode { get; init; }

        public int IVA { get; init; }

        public int weight { get; init; }

        public double price { get; init; }

        public bool active { get; init; }
    }
}