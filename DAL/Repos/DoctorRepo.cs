using DAL.EF;
using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public class DoctorRepo : IDoctorRepo
    {
        private readonly PMSContext _context;

        public DoctorRepo(PMSContext context)
        {
            _context = context;
        }

        public List<Doctor> GetAll() => _context.Doctors.ToList();

        public Doctor GetById(int id) => _context.Doctors.Find(id);

        public void Add(Doctor entity)
        {
            _context.Doctors.Add(entity);
            _context.SaveChanges();
        }

        public void Update(Doctor entity)
        {
            _context.Doctors.Update(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var doc = GetById(id);
            if (doc != null)
            {
                _context.Doctors.Remove(doc);
                _context.SaveChanges();
            }
        }

        public List<Doctor> Search(string name, string specialization, int? minExperience)
        {
            var query = _context.Doctors.AsQueryable();

            if (!string.IsNullOrEmpty(name))
                query = query.Where(d => d.Name.Contains(name));

            if (!string.IsNullOrEmpty(specialization))
                query = query.Where(d => d.Specialization.Contains(specialization));

            if (minExperience.HasValue)
                query = query.Where(d => d.ExperienceYears >= minExperience.Value);

            return query.ToList();
        }
    }
}
