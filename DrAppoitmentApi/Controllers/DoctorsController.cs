using DrAppoitmentApi.Data;
using DrAppoitmentApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DrAppoitmentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly AppDbcontext _context;

        public DoctorsController(AppDbcontext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDoctors()
        {
            var doctors = await _context.Doctors.ToListAsync();
            if (doctors == null || doctors.Count == 0)
                return NoContent();

            return Ok(doctors);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDoctorById(int id)
        {
            var doctor = await _context.Doctors.FindAsync(id);
            if (doctor == null)
                return NotFound("Doctor not found");

            return Ok(doctor);
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchDoctors(string? specialty, string? region)
        {
            var query = _context.Doctors.AsQueryable();

            if (!string.IsNullOrEmpty(specialty))
                query = query.Where(d => d.Specialty.Contains(specialty));

            if (!string.IsNullOrEmpty(region))
                query = query.Where(d => d.Region.Contains(region));

            var doctors = await query.ToListAsync();
            if (doctors == null || doctors.Count == 0)
                return NoContent();

            return Ok(doctors);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDoctor(Doctor doctor)
        {
            _context.Doctors.Add(doctor);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            return Ok(doctor);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDoctor(Doctor doctor)
        {
            var d = await _context.Doctors.FindAsync(doctor.Id);
            if (d == null)
                return NotFound("Doctor not found");

            d.Name = doctor.Name;
            d.Specialty = doctor.Specialty;
            d.Region = doctor.Region;

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
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDoctor(int id)
        {
            var doctor = await _context.Doctors.FindAsync(id);
            if (doctor == null)
                return NotFound("Doctor not found");

            _context.Doctors.Remove(doctor);
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
