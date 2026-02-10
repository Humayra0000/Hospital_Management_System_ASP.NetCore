using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class DoctorDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Specialization { get; set; }
        public int ExperienceYears { get; set; }
        public string Gender { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
    }
}
