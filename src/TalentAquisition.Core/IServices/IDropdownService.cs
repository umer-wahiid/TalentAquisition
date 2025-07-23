using TalentAquisition.Core.Dtos;

namespace TalentAquisition.Core.IServices
{
    public interface IDropdownService
    {
        Task<List<DropdownDto>> GetMilestoneDropdownAsync();
    }
}
