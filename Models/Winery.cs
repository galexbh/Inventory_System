using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory_System.Models
{
    public record Winery
    {

        public int wineryId { get; init; }
        [StringLength(20)]
        public string named { get; init; }
        [StringLength(30)]
        public string location { get; init; }

        public ICollection<Stock> Stock { get; init; }
        public ICollection<BranchOffice> BranchOffice { get; init; }
    }
}