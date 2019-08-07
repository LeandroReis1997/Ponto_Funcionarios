using PointRecord.Models.Employees;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PointRecord.Models.StaffPoint
{
    public class StaffPoints
    {
        public int id { get; set; }
        public int? employeesid { get; set; }
        public Employeees Employees { get; set; }
        public List<Employeees> EmployeesList { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime? date_current { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        [DataType(DataType.Time, ErrorMessage = "Data em formato inválido")]
        public DateTime? start_time1 { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        [DataType(DataType.Time, ErrorMessage = "Data em formato inválido")]
        public DateTime? start_time2 { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        [DataType(DataType.Time, ErrorMessage = "Data em formato inválido")]
        public DateTime? end_time1 { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        [DataType(DataType.Time, ErrorMessage = "Data em formato inválido")]
        public DateTime? end_time2 { get; set; }
        
        public string hours_day { get; set; }
        public TimeSpan? hours_month { get; set; }
    }
}
