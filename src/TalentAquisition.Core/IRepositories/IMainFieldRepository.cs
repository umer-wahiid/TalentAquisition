using TalentAquisition.Core.Dtos;

namespace TalentAquisition.Core.IRepositories
{
    public interface IMainFieldRepository
    {
        Task<List<MainFieldDto>> GetAllAsync();
        Task UpdateAsync(List<MainFieldDto> Dto);
    }
}
