using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class Bill
    {
        [Key]
        public int Id { get; set; }

        public int PatientId { get; set; }
        public virtual Patient Patient { get; set; }

        public int? AppointmentId { get; set; }// nullable
        public virtual Appointment Appointment { get; set; }

        public decimal Amount { get; set; }
        public DateTime BillDate { get; set; }
        public string Status { get; set; } // Paid, Pending, Overdue
        public string PaymentMethod { get; set; }
        public bool IsPaid { get; set; }
    }
}
