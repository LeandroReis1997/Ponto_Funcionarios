using api.system.employees.Models;
using System.Collections.Generic;

namespace api.system.employees.Repository
{
    public interface IEmployeesRepository
    {
        IEnumerable<Employees> GetAll();

        IEnumerable<Employees> FindName(string name);

        Employees Find(long id);

        void add(Employees employees);

        void update(Employees employees);

        void remove(long id);
    }
}
