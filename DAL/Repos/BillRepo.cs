using DAL.EF;
using DAL.EF.Models;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repos
{
    public class BillRepo : IBillRepo
    {
        private readonly PMSContext _context;

        public BillRepo(PMSContext context)
        {
            _context = context;
        }

        public List<Bill> GetAll()
        {
            return _context.Bills.ToList();
        }

        public Bill GetById(int id)
        {
            return _context.Bills.Find(id);
        }

        public void Add(Bill entity)
        {
            _context.Bills.Add(entity);
            _context.SaveChanges();
        }

        public void Update(Bill entity)
        {
            _context.Bills.Update(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var bill = GetById(id);
            if (bill != null)
            {
                _context.Bills.Remove(bill);
                _context.SaveChanges();
            }
        }

        
        // Custom queries
        public List<Bill> GetByPatient(int patientId)
        {
            return _context.Bills
                .Where(b => b.PatientId == patientId)
                .ToList();
        }

        public List<Bill> GetUnpaidBills()
        {
            return _context.Bills
                .Where(b => !b.IsPaid)
                .ToList();
        }
    }
}
