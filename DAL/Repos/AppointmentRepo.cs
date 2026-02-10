using DAL.EF;
using DAL.EF.Models;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public class AppointmentRepo : IAppointmentRepo
    {
        PMSContext _context;

        public AppointmentRepo(PMSContext context)
        {
            _context = context;
        }

        public List<Appointment> GetAll() => _context.Appointments.ToList();

        public Appointment GetById(int id) => _context.Appointments.Find(id);

        public void Add(Appointment entity)
        {
            if (string.IsNullOrWhiteSpace(entity.Reason))
                entity.Reason = "Not specified";

            if (string.IsNullOrWhiteSpace(entity.Status))
                entity.Status = "Scheduled";

            _context.Appointments.Add(entity);
            _context.SaveChanges();
        }

        public void Update(Appointment entity)
        {
            _context.Appointments.Update(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var appt = GetById(id);
            if (appt != null)
            {
                _context.Appointments.Remove(appt);
                _context.SaveChanges();
            }
        }

        public List<Appointment> GetByPatient(int PatientId)
            => _context.Appointments.Where(a => a.PatientId == PatientId).ToList();

        public List<Appointment> GetByDoctor(int DoctorId)
            => _context.Appointments.Where(a => a.DoctorId == DoctorId).ToList();

        public List<Appointment> GetByDateRange(DateTime? start, DateTime? end)
        {
            var query = _context.Appointments.AsQueryable();
            if (start.HasValue) query = query.Where(a => a.AppointmentDate >= start.Value);
            if (end.HasValue) query = query.Where(a => a.AppointmentDate <= end.Value);
            return query.ToList();
        }
    }
}
