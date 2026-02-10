using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly DoctorService _service;

        public DoctorController(DoctorService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<DoctorDTO>> Get() => _service.GetAll();

        [HttpGet("{id}")]
        public ActionResult<DoctorDTO> Get(int id)
        {
            var doc = _service.GetById(id);
            return doc == null ? NotFound() : doc;
        }

        [HttpPost]
        public ActionResult Post([FromBody] DoctorDTO dto)
        {
            if (!ModelState.IsValid) return BadRequest();
            _service.Add(dto);
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] DoctorDTO dto)
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
        public ActionResult<List<DoctorDTO>> Search(
            string name = "",
            string specialization = "",
            int? minExperience = null)
        {
            return _service.Search(name, specialization, minExperience);
        }
    }
}