using System.ComponentModel.DataAnnotations;
using DisasterAlleviation.Models;
using Microsoft.AspNetCore.Identity;

namespace DisasterAlleviation.Models
{
    public class UserReg : IdentityUser
    {
        [Required]
        public string? FullName { get; set; } // Additional field if needed
    }
}
