using Microsoft.AspNetCore.Mvc;
using TalentAquisition.Core.DTOs;
using TalentAquisition.Core.IServices;
using TalentAquisition.Models;

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
            return Json(JsonResponse.Success(statuses));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _service.DeleteAsync(id);
                return Json(JsonResponse.Success(message: "Status deleted successfully"));
            }
            catch (Exception ex)
            {
                return Json(JsonResponse.Error(ex.Message));
            }
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
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();
                return Json(JsonResponse.Error("Validation failed", errors));
            }

            await _service.AddAsync(status);
            return Json(JsonResponse.Success(status, "Status created successfully"));
        }

        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] SetupStatusDto status)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();
                return Json(JsonResponse.Error("Validation failed", errors));
            }

            await _service.UpdateAsync(status);
            return Json(JsonResponse.Success(status, "Status updated successfully"));
        }
    }
}
