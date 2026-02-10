using AutoMapper;
using BLL.DTOs;
using DAL.EF.Models;

namespace BLL
{
    public class MapperConfig
    {
        static MapperConfiguration cfg = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Patient,PatientDTO>().ReverseMap();
            cfg.CreateMap<Doctor, DoctorDTO>().ReverseMap();
            cfg.CreateMap<Appointment, AppointmentDTO>().ReverseMap();
            cfg.CreateMap<Bill, BillDTO>().ReverseMap();
        });
        public static Mapper GetMapper()
        {
            return new Mapper(cfg);
        }

    }
}
