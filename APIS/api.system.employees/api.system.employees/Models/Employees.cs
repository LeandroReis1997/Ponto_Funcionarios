using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.system.employees.Models
{
    [Table("Employees")]
    public class Employees
    {
        public int id { get; set; }
        public string name { get; set; }
        public string cpf { get; set; }
        public string cep { get; set; }
        public string telephone { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string neighborhood { get; set; }
        public DateTime datebirth { get; set; }
        public DateTime dateregister { get; set; }
        public int sectorId { get; set; }
    }
}
