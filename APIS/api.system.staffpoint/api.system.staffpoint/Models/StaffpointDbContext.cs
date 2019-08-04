using Microsoft.EntityFrameworkCore;

namespace api.system.staffpoint.Models
{
    public class StaffpointDbContext : DbContext
    {
        public StaffpointDbContext(DbContextOptions<StaffpointDbContext> options)
            : base(options)
        { }

        public DbSet<StaffPoint> StaffPoints { get; set; }
    }
}
