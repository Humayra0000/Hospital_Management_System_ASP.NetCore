using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace HospitalManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        AppointmentService _service;

        public AppointmentController(AppointmentService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<AppointmentDTO>> Get() => _service.GetAll();

        [HttpGet("{id}")]
        public ActionResult<AppointmentDTO> Get(int id)
        {
            var appt = _service.GetById(id);
            return appt == null ? NotFound() : appt;
        }

        [HttpPost]
        public ActionResult Post([FromBody] AppointmentDTO dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            _service.Add(dto);
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] AppointmentDTO dto)
        {
            if (id != dto.Id) return BadRequest("ID mismatch");
            _service.Update(dto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _service.Delete(id);
            return Ok();
        }

       
        // Filtered 

        [HttpGet("patient/{patientId}")]
        public ActionResult<List<AppointmentDTO>> GetByPatient(int patientId)
        {
            return _service.GetByPatient(patientId);
        }

        [HttpGet("doctor/{doctorId}")]
        public ActionResult<List<AppointmentDTO>> GetByDoctor(int doctorId)
        {
            return _service.GetByDoctor(doctorId);
        }

        [HttpGet("date-range")]
        public ActionResult<List<AppointmentDTO>> GetByDateRange(
            [FromQuery] DateTime? start = null,
            [FromQuery] DateTime? end = null)
        {
            return _service.GetByDateRange(start, end);
        }
    }
}