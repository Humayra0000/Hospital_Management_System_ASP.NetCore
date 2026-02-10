using AutoMapper;
using BLL.DTOs;
using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class BillService
    {
        IBillRepo _repo;
        IMapper _mapper;

        public BillService(IBillRepo repo)
        {
            _repo = repo;
            _mapper = MapperConfig.GetMapper();
        }

        public List<BillDTO> GetAll()
        {
            return _mapper.Map<List<BillDTO>>(_repo.GetAll());
        }

        public BillDTO GetById(int id)
        {
            var bill = _repo.GetById(id);
            return bill == null ? null : _mapper.Map<BillDTO>(bill);
        }

        public void Add(BillDTO dto)
        {
            var entity = _mapper.Map<Bill>(dto);
            _repo.Add(entity);
        }

        public void Update(BillDTO dto)
        {
            var entity = _mapper.Map<Bill>(dto);
            _repo.Update(entity);
        }

        public void Delete(int id)
        {
            _repo.Delete(id);
        }

       
        //queries
        public List<BillDTO> GetByPatient(int patientId)
        {
            var results = _repo.GetByPatient(patientId);
            return _mapper.Map<List<BillDTO>>(results);
        }

        public List<BillDTO> GetUnpaidBills()
        {
            var results = _repo.GetUnpaidBills();
            return _mapper.Map<List<BillDTO>>(results);
        }
    }
}
