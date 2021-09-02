using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory_System.Models
{
    public record Supplier
    {
        [Key]
        public int SupplierId { get; init; }
        [StringLength(50)]
        public string name { get; init; }
        [StringLength(50)]
        public string phoneNumber { get; init; }
        [StringLength(80)]
        public string address { get; init; }
        public ICollection<Product> Product { get; init; }
    }
}