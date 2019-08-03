using System;
using PointRecord.Models.Sector;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace PointRecord.Models.Employees
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
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime? Datebirth { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime? Dateregister { get; set; }
        public int? SectorId { get; set; }
        public Sectors Sectors { get; set; }
        public List<Sectors> Sector { get; set; }
    }
}
