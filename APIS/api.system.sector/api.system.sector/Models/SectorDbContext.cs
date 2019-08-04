using Microsoft.EntityFrameworkCore;

namespace api.system.sector.Models
{
    public class SectorDbContext : DbContext
    {
        public SectorDbContext(DbContextOptions<SectorDbContext> options)
            : base(options)
        { }

        public DbSet<Sector> Sectors { get; set; }
    }
}