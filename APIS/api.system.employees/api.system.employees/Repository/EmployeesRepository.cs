using System;
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
            var employee = new Employees()
            {
                name = employees.name,
                cpf = Converter(employees.cpf),
                cep = Converter(employees.cep),
                telephone = Converter(employees.telephone),
                address = employees.address,
                city = employees.city,
                state = employees.state,
                neighborhood = employees.neighborhood,
                datebirth = employees.datebirth,
                dateregister = employees.dateregister,
                sectorId = employees.sectorId
            };
            _context.Add(employee);
            _context.SaveChanges();
        }

        public Employees Find(long id)
        {
            return _context.Employees.FirstOrDefault(q => q.id == id);
        }

        public IEnumerable<Employees> GetAll()
        {
            return _context.Employees.ToList();
        }

        public void remove(long id)
        {
            try
            {
                var entity = _context.Employees.FirstOrDefault(d => d.id == id);
                _context.Employees.Remove(entity);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw new Exception("Ops! Houve alguma falha durante o processo.");
            }
        }

        public void update(Employees employees)
        {
            _context.Employees.Update(employees);
            _context.SaveChanges();
        }

        private string Converter(string text)
        {
            if (text == null) return null;

            return text.Replace("-", "")
                .Replace(".", "")
                .Replace("(", "")
                .Replace(")", "")
                .Replace(" ", "");
        }
    }
}
