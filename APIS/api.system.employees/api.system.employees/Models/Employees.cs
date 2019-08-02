using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.system.employees.Models
{
    [Table("Employees")]
    public class Employees
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CPF { get; set; }
        public string CEP { get; set; }
        public string Telephone { get; set; }
        public string _Address { get; set; }
        public string City { get; set; }
        public string _State { get; set; }
        public string neighborhood { get; set; }
        public DateTime Datebirth { get; set; }
        public DateTime Dateregister { get; set; }
        public int SectorId { get; set; }
    }
}
