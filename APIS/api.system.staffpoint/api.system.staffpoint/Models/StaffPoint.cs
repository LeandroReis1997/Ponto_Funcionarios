using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.system.staffpoint.Models
{
    [Table("Staffpoint")]
    public class StaffPoint
    {
        public int id { get; set; }
        public int employeesid { get; set; }
        public DateTime date_current { get; set; }
        public DateTime start_time1 { get; set; }
        public DateTime start_time2 { get; set; }
        public DateTime end_time1 { get; set; }
        public DateTime end_time2 { get; set; }
        public string hours_day { get; set; }
        public string hours_month { get; set; }
}
}
