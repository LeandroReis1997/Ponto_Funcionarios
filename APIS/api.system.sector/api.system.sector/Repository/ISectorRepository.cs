using api.system.sector.Models;
using System.Collections.Generic;

namespace api.system.sector.Repository
{
    public interface ISectorRepository
    {

        IEnumerable<Sector> GetAll();

        IEnumerable<Sector> GetAllOrderBy();

        IEnumerable<Sector> FindName(string name);

        Sector Find(long id);

        void add(Sector sector);

        void update(Sector sector);

        void remover(long id);
    }
}
