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
    public class DoctorService
    {
        IDoctorRepo _repo;
        IMapper _mapper;

        public DoctorService(IDoctorRepo repo)
        {
            _repo = repo;
            _mapper = MapperConfig.GetMapper();
        }

        public List<DoctorDTO> GetAll()
        {
            return _mapper.Map<List<DoctorDTO>>(_repo.GetAll());
        }

        public DoctorDTO GetById(int id)
        {
            var doc = _repo.GetById(id);
            return doc == null ? null : _mapper.Map<DoctorDTO>(doc);
        }

        public void Add(DoctorDTO dto)
        {
            var entity = _mapper.Map<Doctor>(dto);
            _repo.Add(entity);
        }

        public void Update(DoctorDTO dto)
        {
            var entity = _mapper.Map<Doctor>(dto);
            _repo.Update(entity);
        }

        public void Delete(int id)
        {
            _repo.Delete(id);
        }

        public List<DoctorDTO> Search(string name, string specialization, int? minExperience)
        {
            var results = _repo.Search(name, specialization, minExperience);
            return _mapper.Map<List<DoctorDTO>>(results);
        }
    }
}
