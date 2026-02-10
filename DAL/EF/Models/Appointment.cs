using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class Appointment
    {
        [Key]
        public int Id { get; set; }
        public int PatientId { get; set; }
        public virtual Patient Patient { get; set; }   
        public int DoctorId { get; set; }
        public virtual Doctor Doctor { get; set; }   

        public DateTime AppointmentDate { get; set; }
        public string Status { get; set; } //"Scheduled", "Completed", "Cancelled"

        [StringLength(500)]
        public string Reason { get; set; }
    }
}
