using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.system.staffpoint.Models
{
    [Table("Staffpoint")]
    public class StaffPoint
    {
        public int Id { get; set; }
        public int EmployeesId { get; set; }
        public DateTime DateCurrent  { get; set; }
        public DateTime StartTime1 { get; set; }
        public DateTime StartTime2 { get; set; }
        public DateTime EndTime1 { get; set; }
        public DateTime EndTime2 { get; set; }
        public string Hoursday { get; set; }
    }
}
