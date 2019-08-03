using api.system.sector.Models;
using System.Collections.Generic;

namespace api.system.sector.Repository
{
    public interface ISectorRepository
    {
        void add(Sector sector);

        IEnumerable<Sector> GetAll();

        IEnumerable<Sector> GetAllOrderBy();

        Sector Find(long id);

        void update(Sector sector);

        void remover(long id);
    }
}
