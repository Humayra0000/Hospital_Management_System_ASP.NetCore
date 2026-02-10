using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillController : ControllerBase
    {
        private readonly BillService _service;

        public BillController(BillService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<BillDTO>> Get() => _service.GetAll();

        [HttpGet("{id}")]
        public ActionResult<BillDTO> Get(int id)
        {
            var bill = _service.GetById(id);
            return bill == null ? NotFound() : bill;
        }

        [HttpPost]
        public ActionResult Post([FromBody] BillDTO dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            _service.Add(dto);
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] BillDTO dto)
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
        public ActionResult<List<BillDTO>> GetByPatient(int patientId)
        {
            return _service.GetByPatient(patientId);
        }

        [HttpGet("unpaid")]
        public ActionResult<List<BillDTO>> GetUnpaidBills()
        {
            return _service.GetUnpaidBills();
        }
    }
}