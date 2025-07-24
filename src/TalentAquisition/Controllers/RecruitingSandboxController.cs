using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TalentAquisition.Core.Dtos;
using TalentAquisition.Core.IServices;
using TalentAquisition.Models;

namespace TalentAquisition.Controllers
{
    public class RecruitingSandboxController : Controller
    {
        private readonly IMainEmployeeService _service;
        private readonly IDropdownService _ddlService;

        public RecruitingSandboxController(IMainEmployeeService service, IDropdownService ddlService)
        {
            _service = service;
            _ddlService = ddlService;
        }

        public IActionResult Index()
        {
            ViewData["Title"] = "Lead";
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var respone = await _service.GetAllAsync();
            return Json(respone);
        }
    }
}
