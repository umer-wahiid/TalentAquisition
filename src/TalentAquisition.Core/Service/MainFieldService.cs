using TalentAquisition.Core.Dtos;
using TalentAquisition.Core.IServices;
using TalentAquisition.Core.IRepositories;

namespace TalentAquisition.Infrastructure.Repositories
{
    public class MainFieldService : IMainFieldService
    {
        public IMainFieldRepository _mainFieldRepository { get; set; }
        public MainFieldService(IMainFieldRepository mainFieldRepository)
        {
            _mainFieldRepository = mainFieldRepository;
        }

        public async Task<List<MainFieldDto>> GetAllAsync()
        {
            return await _mainFieldRepository.GetAllAsync();
        }

        public async Task UpdateAsync(List<MainFieldDto> dto)
        {
            await _mainFieldRepository.UpdateAsync(dto);
        }
    }
}
