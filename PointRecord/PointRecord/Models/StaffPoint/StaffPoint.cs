using PointRecord.Models.Employees;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PointRecord.Models.StaffPoint
{
    public class StaffPoint
    {
        public int Id { get; set; }
        public int? EmployeesId { get; set; }
        public Employeees Employees { get; set; }
        public List<Employeees> EmployeesList { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime? DateCurrent { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        [DataType(DataType.Time, ErrorMessage = "Data em formato inválido")]
        public DateTime? StartTime1 { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        [DataType(DataType.Time, ErrorMessage = "Data em formato inválido")]
        public DateTime? StartTime2 { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        [DataType(DataType.Time, ErrorMessage = "Data em formato inválido")]
        public DateTime? EndTime1 { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        [DataType(DataType.Time, ErrorMessage = "Data em formato inválido")]
        public DateTime? EndTime2 { get; set; }
        
        public string Hoursday { get; set; }
    }
}
