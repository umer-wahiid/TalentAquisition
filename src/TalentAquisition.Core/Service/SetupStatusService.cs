using TalentAquisition.Core.DTOs;
using TalentAquisition.Core.IServices;
using TalentAquisition.Core.IRepositories;

namespace TalentAquisition.Infrastructure.Repositories
{
    public class SetupStatusService : ISetupStatusService
    {
        public ISetupStatusRepository _setupStatusRepository { get; set; }
        public SetupStatusService(ISetupStatusRepository setupStatusRepository)
        {
            _setupStatusRepository = setupStatusRepository;
        }

        public async Task AddAsync(SetupStatusDto entity)
        {
            await _setupStatusRepository.AddAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _setupStatusRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<SetupStatusDto>> GetAllAsync()
        {
            return await _setupStatusRepository.GetAllAsync();
        }

        public async Task<SetupStatusDto> GetByIdAsync(int id)
        {
            return await _setupStatusRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(SetupStatusDto entity)
        {
            await _setupStatusRepository.UpdateAsync(entity);
        }
    }
}
