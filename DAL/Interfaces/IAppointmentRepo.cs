using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IAppointmentRepo : IRepository<Appointment>
    {
        List<Appointment> GetByPatient(int patientId);
        List<Appointment> GetByDoctor(int doctorId);
        List<Appointment> GetByDateRange(DateTime? start, DateTime? end);
    }
}
