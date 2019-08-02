using System.ComponentModel.DataAnnotations.Schema;

namespace PointRecord.Models.Sector
{
    [Table("Sector")]
    public class Sectors
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
    }
}
