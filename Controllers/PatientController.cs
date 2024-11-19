using HMSERM.Data;
using HMSERM.Dtos;
using HMSERM.Interface.Repository;
using HMSERM.Interface.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HMSERM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IPatientService _patientService;
        private readonly ApplicationDbContext _dbContext;

        public PatientController(IPatientRepository patientRepository, IPatientService patientService, ApplicationDbContext dbContext)
        {
            _patientRepository = patientRepository;
            _patientService = patientService;
            _dbContext = dbContext;
        }

        // GET: api/<PatientController>
        [HttpGet("GetAllPatients")]
        public async Task<IActionResult> GetAllPatients()
        {
            var result = await _patientService.GetAllPatients();
            return Ok(result);
        }

        // GET api/<PatientController>/5
        [HttpGet("GetPatientById/{patientId}")]
        public async Task<IActionResult> GetPatientById(int patientId)
        {
            var patient = await _dbContext.Patients
                          .Where(x => x.PatientId == patientId)
                          .ToListAsync();

            if (patient == null)
            {
                return NotFound("Patient Not Exist");
            }

            return new OkObjectResult(patient);
        }

        // POST api/<PatientController>
        [HttpPost("AddPatient")]
        public async Task<IActionResult> AddAsync([FromBody] PatientDto dto)
        {
            var result = await _patientService.AddPatient(dto);
            return Ok(result);
        }

        // PUT api/<PatientController>/5
        [HttpPut("UpdatePatient")]
        public async Task<IActionResult> UpdateAsync(int id, PatientDto dto)
        {
            var result = await _patientService.UpdatePatient(id, dto);
            return Ok(result);
        }

        // DELETE api/<PatientController>/5
        [HttpDelete("DeletePatient")]
        public async Task<IActionResult> DeletePatient(int id)
        {
            var result = await _patientService.DeletePatient(id);
            return NoContent();
        }
    }
}
