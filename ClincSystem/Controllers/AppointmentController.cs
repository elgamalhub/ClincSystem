using ClincSystem.DAL.Entities;
using ClincSystem.DAL.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClincSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public AppointmentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var appointments = await _unitOfWork.Appointments.GetAllAsync();
            return Ok(appointments);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var appointment = await _unitOfWork.Appointments.GetByIdAsync(id);
            if (appointment == null)
                return NotFound();
            return Ok(appointment);
        }
        [HttpPost]
        public async Task<IActionResult> Create(Appointment appointment)
        {
            await _unitOfWork.Appointments.CreateAsync(appointment);
            await _unitOfWork.SaveAsync();
            return CreatedAtAction(nameof(GetById), new { id = appointment.AppointmentId }, appointment);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Appointment appointment)
        {
            if (id != appointment.AppointmentId)
                return BadRequest();

            await _unitOfWork.Appointments.UpdateAsync(appointment);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _unitOfWork.Appointments.DeleteByIdAsync(id);
            if (!deleted)
                return NotFound();

            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}
