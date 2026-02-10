using AutoMapper;
using BLL.DTOs;
using DAL.EF.Models;
using DAL.Interfaces;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class PatientService
    {
        IPatientRepo _repo;
        IMapper _mapper;

        public PatientService(IPatientRepo repo)
        {
            _repo = repo;
            _mapper = MapperConfig.GetMapper();
        }

        public List<PatientDTO> GetAll()
        {
            var patients = _repo.GetAll();
            return _mapper.Map<List<PatientDTO>>(patients);
        }

        public PatientDTO GetById(int id)
        {
            var patient = _repo.GetById(id);
            return _mapper.Map<PatientDTO>(patient);
        }

        public void Add(PatientDTO dto)
        {
            var patient = _mapper.Map<Patient>(dto);
            _repo.Add(patient);
        }

        public void Update(PatientDTO dto)
        {
            var patient = _mapper.Map<Patient>(dto);
            _repo.Update(patient);
        }

        public void Delete(int id)
        {
            _repo.Delete(id);
        }

        
        public List<PatientDTO> Search(string name, int? minAge, int? maxAge)
        {
            var patients = _repo.SearchByNameOrAge(name, minAge, maxAge);
            return _mapper.Map<List<PatientDTO>>(patients);
        }
    }
}
