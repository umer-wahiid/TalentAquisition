using TalentAquisition.Core.Dtos;
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

        public async Task<Response<int>> AddAsync(SetupStatusDto dto)
        {
            return await _setupStatusRepository.AddAsync(dto);
        }

        public async Task<Response<bool>> DeleteAsync(int id)
        {
            return await _setupStatusRepository.DeleteAsync(id);
        }

        public async Task<Response<IEnumerable<SetupStatusDto>>> GetAllAsync()
        {
            return await _setupStatusRepository.GetAllAsync();
        }

        public async Task<Response<SetupStatusDto>> GetByIdAsync(int id)
        {
            return await _setupStatusRepository.GetByIdAsync(id);
        }

        public async Task<Response<bool>> UpdateAsync(SetupStatusDto dto)
        {
            return await _setupStatusRepository.UpdateAsync(dto);
        }
    }
}
