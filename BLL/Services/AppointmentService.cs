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
    public class AppointmentService
    {
         IAppointmentRepo _repo;
         IMapper _mapper;

        public AppointmentService(IAppointmentRepo repo)
        {
            _repo = repo;
            _mapper = MapperConfig.GetMapper();
        }

        public List<AppointmentDTO> GetAll()
        {
            return _mapper.Map<List<AppointmentDTO>>(_repo.GetAll());
        }

        public AppointmentDTO GetById(int id)
        {
            var appointment = _repo.GetById(id);
            return appointment == null ? null : _mapper.Map<AppointmentDTO>(appointment);
        }

        public void Add(AppointmentDTO dto)
        {
            var entity = _mapper.Map<Appointment>(dto);
            _repo.Add(entity);
        }

        public void Update(AppointmentDTO dto)
        {
            var entity = _mapper.Map<Appointment>(dto);
            _repo.Update(entity);
        }

        public void Delete(int id)
        {
            _repo.Delete(id);
        }

        
        //queries
        
        public List<AppointmentDTO> GetByPatient(int patientId)
        {
            var results = _repo.GetByPatient(patientId);
            return _mapper.Map<List<AppointmentDTO>>(results);
        }

        public List<AppointmentDTO> GetByDoctor(int doctorId)
        {
            var results = _repo.GetByDoctor(doctorId);
            return _mapper.Map<List<AppointmentDTO>>(results);
        }

        public List<AppointmentDTO> GetByDateRange(DateTime? start, DateTime? end)
        {
            var results = _repo.GetByDateRange(start, end);
            return _mapper.Map<List<AppointmentDTO>>(results);
        }
    }
}
