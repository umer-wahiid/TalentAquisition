using Microsoft.AspNetCore.Mvc;
using TalentAquisition.Core.DTOs;
using TalentAquisition.Core.Interfaces;

namespace TalentAquisition.Controllers
{
    public class SetupStatusController : Controller
    {
        private readonly ISetupStatusRepository _repository;

        public SetupStatusController(ISetupStatusRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var statuses = await _repository.GetAllAsync();
            return Json(new
            {
                success = true,
                data = statuses
            });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _repository.DeleteAsync(id);
            return Json(new { success = true, message = "Delete successful" });
        }

        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            var status = await _repository.GetByIdAsync(id);
            if (status == null)
            {
                return NotFound();
            }
            return Json(new
            {
                success = true,
                data = status
            });
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SetupStatusDto status)
        {
            if (ModelState.IsValid)
            {
                await _repository.AddAsync(status);
                return Json(new
                {
                    success = true,
                    message = "Added successfully",
                    data = status
                });
            }
            return BadRequest(ModelState);
        }

        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] SetupStatusDto status)
        {
            if (ModelState.IsValid)
            {
                await _repository.UpdateAsync(status);
                return Json(new
                {
                    success = true,
                    message = "Updated successfully",
                    data = status
                });
            }
            return BadRequest(ModelState);
        }
    }
}
