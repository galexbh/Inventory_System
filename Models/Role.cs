using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory_System.Models
{
    public record Role
    {
        [ForeignKey("User")]
        public int RoleId { get; init; }
        [StringLength(20)]
        public string name { get; init; }
        [StringLength(140)]
        public string description { get; init; }

        public virtual User User { get; init; }
    }
}