using System.Collections.Generic;
using System.Linq;
using api.system.sector.Models;

namespace api.system.sector.Repository
{
    public class SectorRepository : ISectorRepository
    {
        private readonly SectorDbContext _context;

        public SectorRepository(SectorDbContext ctx)
        {
            _context = ctx;
        }

        public void add(Sector sector)
        {
            _context.Add(sector);
            _context.SaveChanges();
        }

        public Sector Find(long id)
        {
            return _context.Sectors.FirstOrDefault(v => v.Id == id);
        }

        public IEnumerable<Sector> GetAll()
        {
            return _context.Sectors.ToList();
        }

        public IEnumerable<Sector> GetAllOrderBy()
        {
            return _context.Sectors.Where(x => x.Active == true).ToList();
        }

        public void remover(long id)
        {
            var entity = _context.Sectors.First(w => w.Id == id);
            _context.Sectors.Remove(entity);
            _context.SaveChanges();
        }

        public void update(Sector sector)
        {
            _context.Sectors.Update(sector);
            _context.SaveChanges();
        }
    }
}
