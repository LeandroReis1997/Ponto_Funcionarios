using System;
using PointRecord.Models.Sector;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using PointRecord.Models.StaffPoint;

namespace PointRecord.Models.Employees
{
    [Table("Employees")]
    public class Employeees
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
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime? datebirth { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime? dateregister { get; set; }
        public int? sectorId { get; set; }
        public Sectors Sectors { get; set; }
        public List<Sectors> Sector { get; set; }
        public StaffPoints StaffPoint { get; set; }
    }
}
