using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory_System.Models
{
    public record User
    {
        [ForeignKey("branchOffice")]
        public int UserId { get; init; }
        public int RoleId { get; init; }
        [StringLength(20)]
        public string name { get; init; }
        [StringLength(20)]
        public string secondName { get; init; }
        [StringLength(20)]
        public string sureName { get; init; }
        [StringLength(20)]
        public string lastName { get; init; }
        public int age { get; init; }
        [StringLength(250)]
        [EmailAddress(ErrorMessage = "email no valid")]
        [Required(ErrorMessage = "this field is required")]
        public string email { get; init; }
        public byte[] passwordHash { get; set; }
        public byte[] passwordSalt { get; set; }
        public DateTime dateCreation { get; init; }
        public bool active { get; init; }

        public Role Role { get; init; }
        public virtual BranchOffice BranchOffice { get; init; }
    }
}