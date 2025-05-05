using ClincSystem.DAL.Entities;
using ClincSystem.DAL.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClincSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecializationController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public SpecializationController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var specializations = await _unitOfWork.Specializations.GetAllAsync();
            return Ok(specializations);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var specialization = await _unitOfWork.Specializations.GetByIdAsync(id);
            return specialization == null ? NotFound() : Ok(specialization);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Specialization specialization)
        {
            await _unitOfWork.Specializations.CreateAsync(specialization);
            await _unitOfWork.SaveAsync();
            return CreatedAtAction(nameof(GetById), new { id = specialization.SpecializationId }, specialization);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Specialization specialization)
        {
            if (id != specialization.SpecializationId)
                return BadRequest();

            await _unitOfWork.Specializations.UpdateAsync(specialization);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _unitOfWork.Specializations.DeleteByIdAsync(id);
            if (!deleted)
                return NotFound();

            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}
