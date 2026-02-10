using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class Doctor
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(100)]
        public string Name { get; set; }
        [StringLength(100)]
        public string Specialization { get; set; }
        public int ExperienceYears { get; set; }
        [StringLength(20)]
        public string Gender { get; set; }
        [StringLength(50)]
        public string Contact { get; set; }
        [StringLength(150)]
        public string Email { get; set; }
    }
}
