using Microsoft.AspNetCore.Mvc;
using TalentAquisition.Core.Dtos;
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
            var respone = await _service.GetAllAsync();
            return Json(respone);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var respone = await _service.DeleteAsync(id);
                return Json(respone);
            }
            catch (Exception ex)
            {
                return Json(JsonResponse.Error(ex.Message));
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _service.GetByIdAsync(id);
            return Json(response);
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

            var response = await _service.AddAsync(status);
            return Json(response);
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

            var response = await _service.UpdateAsync(status);
            return Json(response);
        }
    }
}
