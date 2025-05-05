using ClincSystem.DAL.Entities;
using ClincSystem.DAL.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClincSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentSlotController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public AppointmentSlotController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var appointments = await _unitOfWork.AppointmentSlots.GetAllAsync();
            return Ok(appointments);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var appointment = await _unitOfWork.AppointmentSlots.GetByIdAsync(id);
            if (appointment == null)
                return NotFound();
            return Ok(appointment);
        }
        [HttpPost]
        public async Task<IActionResult> Create(AppointmentSlot appointment)
        {
            await _unitOfWork.AppointmentSlots.CreateAsync(appointment);
            await _unitOfWork.SaveAsync();
            return CreatedAtAction(nameof(GetById), new { id = appointment.SlotId }, appointment);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, AppointmentSlot appointment)
        {
            if (id != appointment.SlotId)
                return BadRequest();

            await _unitOfWork.AppointmentSlots.UpdateAsync(appointment);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _unitOfWork.AppointmentSlots.DeleteByIdAsync(id);
            if (!deleted)
                return NotFound();

            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}
