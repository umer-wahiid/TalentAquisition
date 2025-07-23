using TalentAquisition.Core.Dtos;

namespace TalentAquisition.Core.IRepositories
{
    public interface IDropdownRepository
    {
        Task<List<DropdownDto>> GetMilestoneDropdownAsync();
    }
}
