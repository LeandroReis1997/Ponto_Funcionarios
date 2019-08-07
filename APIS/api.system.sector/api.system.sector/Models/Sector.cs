using System.ComponentModel.DataAnnotations.Schema;

namespace api.system.sector.Models
{
    [Table("Sector")]
    public class Sector
    {
        public int id { get; set; }
        public string name { get; set; }
        public bool active { get; set; }
    }
}
