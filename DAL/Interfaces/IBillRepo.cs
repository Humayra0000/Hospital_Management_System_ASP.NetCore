using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IBillRepo : IRepository<Bill>
    {
        List<Bill> GetByPatient(int patientId);
        List<Bill> GetUnpaidBills();
    }
}
