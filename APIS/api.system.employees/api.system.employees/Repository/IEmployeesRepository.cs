using api.system.employees.Models;
using System.Collections.Generic;

namespace api.system.employees.Repository
{
    public interface IEmployeesRepository
    {
        void add(Employees employees);

        IEnumerable<Employees> GetAll();

        Employees Find(long id);

        void update(Employees employees);

        void remove(long id);
    }
}
