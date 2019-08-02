using System.ComponentModel.DataAnnotations.Schema;

namespace api.system.sector.Models
{
    [Table("Sector")]
    public class Sector
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
    }
}
