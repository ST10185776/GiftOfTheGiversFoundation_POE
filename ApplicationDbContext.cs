using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DisasterAlleviation.Models;

namespace DisasterAlleviation.Data
{
    public class ApplicationDbContext : IdentityDbContext<UserReg>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<IncidentReport> IncidentReports { get; set; } // Incident reports table

        public DbSet<ResourceDonation> ResourceDonations { get; set; } // Resource donations table

    }
}
