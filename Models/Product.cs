using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory_System.Models
{
    public record Product
    {
        [ForeignKey("Stock")]
        public int ProductId { get; init; }
        public Supplier Supplier { get; init; }
        [StringLength(30)]
        public string brand { get; init; }
        [StringLength(30)]
        public string presentation { get; init; }
        [StringLength(140)]
        public string description { get; init; }
        [StringLength(60)]
        public string internalCode { get; init; }
        public int IVA { get; init; }
        public int weight { get; init; }
        public double price { get; init; }

        public virtual Stock Stock { get; init; }
    }
}