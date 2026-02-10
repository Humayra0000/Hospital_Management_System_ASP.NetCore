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
    public class PatientRepo : IPatientRepo
    {
        PMSContext _context;

        public PatientRepo(PMSContext context)
        {
            _context = context;
        }

        public List<Patient> GetAll()
        {
            return _context.Patients.ToList();
        }

        public Patient GetById(int id)
        {
            return _context.Patients.Find(id);
        }

        public void Add(Patient patient)
        {
            _context.Patients.Add(patient);
            _context.SaveChanges();
        }

        public void Update(Patient patient)
        {
          
        }

        public void Delete(int id)
        {
            var patient = GetById(id);
            if (patient != null)
            {
                _context.Patients.Remove(patient);
                _context.SaveChanges();
            }
        }

        public List<Patient> SearchByNameOrAge(string name, int? minAge, int? maxAge)
        {
            var query = _context.Patients.AsQueryable();

            if (!string.IsNullOrEmpty(name))
                query = query.Where(p => p.Name.Contains(name));

            if (minAge.HasValue)
                query = query.Where(p => p.Age >= minAge.Value);

            if (maxAge.HasValue)
                query = query.Where(p => p.Age <= maxAge.Value);

            return query.ToList();
        }
    }
}
