using System;
using System.Collections.Generic;
using System.Linq;
using api.system.staffpoint.Models;

namespace api.system.staffpoint.Repository
{
    public class StaffpointRepository : IStaffpointRepository
    {
        private readonly StaffpointDbContext _context;

        public StaffpointRepository(StaffpointDbContext ctx)
        {
            _context = ctx;
        }

        public void add(StaffPoint staffPoint)
        {
            _context.Add(staffPoint);
            _context.SaveChanges();
        }

        public StaffPoint Find(long id)
        {
            return _context.StaffPoints.FirstOrDefault(x => x.id == id);
        }

        public IEnumerable<StaffPoint> GetAll()
        {
            return _context.StaffPoints.ToList();
        }

        public void remover(long id)
        {
            var entity = _context.StaffPoints.FirstOrDefault(x => x.id == id);
            _context.StaffPoints.Remove(entity);
            _context.SaveChanges();
        }

        public void update(StaffPoint staffPoint)
        {
            _context.Update(staffPoint);
            _context.SaveChanges();
        }
    }
}
