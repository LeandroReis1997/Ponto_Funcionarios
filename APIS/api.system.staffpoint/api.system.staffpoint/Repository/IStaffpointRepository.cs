using api.system.staffpoint.Models;
using System.Collections.Generic;

namespace api.system.staffpoint.Repository
{
    public interface IStaffpointRepository
    {
        void add(StaffPoint staffPoint);

        IEnumerable<StaffPoint> GetAll();

        StaffPoint Find(long id);

        void update(StaffPoint staffPoint);

        void remover(long id);
    }
}
