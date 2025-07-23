using TalentAquisition.Core.Dtos;
using TalentAquisition.Core.IServices;
using TalentAquisition.Core.IRepositories;

namespace TalentAquisition.Infrastructure.Repositories
{
    public class DropdownService : IDropdownService
    {
        public IDropdownRepository _dropdownRepository { get; set; }
        public DropdownService(IDropdownRepository dropdownRepository)
        {
            _dropdownRepository = dropdownRepository;
        }

        public async Task<List<DropdownDto>> GetMilestoneDropdownAsync()
        {
            return await _dropdownRepository.GetMilestoneDropdownAsync();
        }
    }
}
