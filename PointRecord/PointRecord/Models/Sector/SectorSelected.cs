using System.Collections.Generic;

namespace PointRecord.Models.Sector
{
    public class SectorSelected
    {
        public string Name { get; set; }
        public IEnumerable<Sectors> SectorsList { get; set; }

        public Sectors Sector { get; set; }

        public SectorSelected()
        {
            this.Sector = new Sectors();
            this.SectorsList = new List<Sectors>();
        }
    }
}
