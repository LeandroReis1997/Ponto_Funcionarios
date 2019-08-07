using System.ComponentModel.DataAnnotations.Schema;

namespace PointRecord.Models.Sector
{
    [Table("Sector")]
    public class Sectors
    {
        public int id { get; set; }
        public string name { get; set; }
        public bool active { get; set; }

        public Sectors()
        {
            this.active = true;
        }
    }
}
