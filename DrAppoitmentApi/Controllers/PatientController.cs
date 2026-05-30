using DrAppoitmentApi.Data;
using DrAppoitmentApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DrAppoitmentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly AppDbcontext _context;

        public PatientController(AppDbcontext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAppointments()
        {
            var appointments = await _context.Patients.ToListAsync();
            if (appointments == null || appointments.Count == 0)
                return NoContent();

            return Ok(appointments);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAppointmentById(int id)
        {
            var appointment = await _context.Patients.FindAsync(id);
            if (appointment == null)
                return NotFound("Appointment not found");

            return Ok(appointment);
        }

        [HttpPost]
        public async Task<IActionResult> BookAppointment(Patient patient)
        {
            _context.Patients.Add(patient);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            return Ok(patient);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> CancelAppointment(int id)
        {
            var appointment = await _context.Patients.FindAsync(id);
            if (appointment == null)
                return NotFound("Appointment not found");

            _context.Patients.Remove(appointment);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            return Ok();
        }
    }
}
