using Microsoft.EntityFrameworkCore;

namespace api.system.employees.Models
{
    public class EmployeesDbContext : DbContext
    {
        public EmployeesDbContext(DbContextOptions<EmployeesDbContext> options)
            : base(options)
        { }

        public DbSet<Employees> Employees { get; set; }
    }
}
