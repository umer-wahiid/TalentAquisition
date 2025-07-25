using TalentAquisition.Core.Dtos;

namespace TalentAquisition.Core.IServices
{
    public interface IDropdownService
    {
        Task<List<DropdownDto>> GetMilestoneDropdownAsync();
        Task<List<DropdownDto>> GetLeadSourceDropdownAsync();
        Task<List<DropdownDto>> GetStatusDropdownAsync();
        Task<List<DropdownDto>> GetTypeDropdownAsync();
        Task<List<DropdownDto>> GetCompanyDropdownAsync();
        Task<List<DropdownDto>> GetStateDropdownAsync();
        Task<List<DropdownDto>> GetHierarchyDropdownAsync();
    }
}
