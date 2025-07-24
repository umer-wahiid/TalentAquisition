using Microsoft.AspNetCore.Mvc;
using TalentAquisition.Core.Dtos;
using TalentAquisition.Core.IServices;
using TalentAquisition.Models;

namespace TalentAquisition.Controllers
{
    public class RequiredFieldsController : Controller
    {
        private readonly IMainFieldService _service;
        private readonly IDropdownService _ddlService;

        public RequiredFieldsController(IMainFieldService service, IDropdownService ddlService)
        {
            _service = service;
            _ddlService = ddlService;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["Title"] = "Required Fields";
            ViewBag.Milestones = await _ddlService.GetMilestoneDropdownAsync();
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _service.GetAllAsync();
            return Json(response);
        }

            [HttpPost]
            public async Task<IActionResult> Edit([FromBody] List<MainFieldDto> field)
            {
                if (!ModelState.IsValid)
                {
                    var errors = ModelState.Values
                        .SelectMany(v => v.Errors)
                        .Select(e => e.ErrorMessage)
                        .ToList();
                    return Json(JsonResponse.Error("Validation failed", errors));
                }

                var response = await _service.UpdateAsync(field);
                return Json(response);
            }
    }
}
