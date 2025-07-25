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
        
        public async Task<IActionResult> Create()
        {
            ViewData["Title"] = "Create Lead";
            ViewBag.LeadSource = await _ddlService.GetLeadSourceDropdownAsync();
            ViewBag.Status = await _ddlService.GetStatusDropdownAsync();
            ViewBag.Type = await _ddlService.GetTypeDropdownAsync();
            ViewBag.Company = await _ddlService.GetCompanyDropdownAsync();
            ViewBag.State = await _ddlService.GetStateDropdownAsync();
            ViewBag.Hierarchy = await _ddlService.GetHierarchyDropdownAsync();

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
