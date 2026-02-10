using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        PatientService _service;

        public PatientController(PatientService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<PatientDTO>> Get() 
        {
            return _service.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<PatientDTO> Get(int id) 
        {
            var patient = _service.GetById(id);
            if (patient == null) return NotFound();
            return patient;
        }

        [HttpPost]
        public ActionResult Post([FromBody] PatientDTO dto) 
        {
            if (!ModelState.IsValid) return BadRequest();
            _service.Add(dto);
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] PatientDTO dto) 
        {
            if (id != dto.Id) return BadRequest();
            _service.Update(dto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id) 
        {
            _service.Delete(id);
            return Ok();
        }

        
        [HttpGet("search")]
        public ActionResult<List<PatientDTO>> Search(string name = "", int? minAge = null, int? maxAge = null)
        {
            return _service.Search(name, minAge, maxAge);
        }
    }
}
