using System;
using System.ComponentModel.DataAnnotations;

namespace BLL.DTOs
{
    public class BillDTO
    {
        public int Id { get; set; }

        [Required]
        public int PatientId { get; set; }

        public int? AppointmentId { get; set; }

        [Required]
        public decimal Amount { get; set; }

        public DateTime BillDate { get; set; }

        [Required, StringLength(20)]
        public string Status { get; set; }   // Paid / Pending 

        [StringLength(50)]
        public string PaymentMethod { get; set; }

        public bool IsPaid { get; set; }
    }

}
