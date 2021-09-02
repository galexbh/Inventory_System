using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory_System.Models
{
    public record BranchOffice
    {
        public int BranchOfficeId { get; init; }
        public int UserId { get; init; }
        public Winery Winery { get; init; }
        [StringLength(20)]
        public string name { get; init; }

        public User User { get; init; }
    }
}