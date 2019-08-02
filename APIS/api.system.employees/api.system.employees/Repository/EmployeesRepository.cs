using System.Collections.Generic;
using System.Linq;
using api.system.employees.Models;

namespace api.system.employees.Repository
{
    public class EmployeesRepository : IEmployeesRepository
    {
        private readonly EmployeesDbContext _context;

        public EmployeesRepository(EmployeesDbContext ctx)
        {
            _context = ctx;
        }

        public void add(Employees employees)
        {
            _context.Add(employees);
            _context.SaveChanges();
        }

        public Employees Find(long id)
        {
            return _context.Employees.FirstOrDefault(q => q.Id == id);
        }

        public IEnumerable<Employees> GetAll()
        {
            return _context.Employees.ToList();
        }

        public void remove(long id)
        {
            var entity = _context.Employees.FirstOrDefault(d => d.Id == id);
            _context.Employees.Remove(entity);
            _context.SaveChanges();
        }

        public void update(Employees employees)
        {
            _context.Employees.Update(employees);
            _context.SaveChanges();
        }
    }
}
