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

        public async Task<List<DropdownDto>> GetLeadSourceDropdownAsync()
        {
            return await _dropdownRepository.GetLeadSourceDropdownAsync();
        }

        public async Task<List<DropdownDto>> GetStatusDropdownAsync()
        {
            return await _dropdownRepository.GetStatusDropdownAsync();
        }

        public async Task<List<DropdownDto>> GetTypeDropdownAsync()
        {
            return await _dropdownRepository.GetTypeDropdownAsync();
        }

        public async Task<List<DropdownDto>> GetCompanyDropdownAsync()
        {
            return await _dropdownRepository.GetCompanyDropdownAsync();
        }

        public async Task<List<DropdownDto>> GetStateDropdownAsync()
        {
            return await _dropdownRepository.GetStateDropdownAsync();
        }

        public async Task<List<DropdownDto>> GetHierarchyDropdownAsync()
        {
            return await _dropdownRepository.GetHierarchyDropdownAsync();
        }

    }
}
