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

        public async Task<Response<IEnumerable<MainFieldDto>>> GetAllAsync()
        {
            return await _mainFieldRepository.GetAllAsync();
        }

        public async Task<Response<bool>> UpdateAsync(List<MainFieldDto> dto)
        {
            return await _mainFieldRepository.UpdateAsync(dto);
        }
    }
}
