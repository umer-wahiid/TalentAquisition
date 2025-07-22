using Microsoft.AspNetCore.Mvc;
using TalentAquisition.Core.DTOs;
using TalentAquisition.Core.IServices;

namespace TalentAquisition.Controllers
{
    public class SetupStatusController : Controller
    {
        private readonly ISetupStatusService _service;

        public SetupStatusController(ISetupStatusService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            ViewData["Title"] = "Setup Status";
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var statuses = await _service.GetAllAsync();
            return Json(new
            {
                success = true,
                data = statuses
            });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return Json(new { success = true, message = "Delete successful" });
        }

        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            var status = await _service.GetByIdAsync(id);
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
                await _service.AddAsync(status);
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
                await _service.UpdateAsync(status);
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
