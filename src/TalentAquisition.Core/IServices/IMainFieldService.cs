using TalentAquisition.Core.Dtos;

namespace TalentAquisition.Core.IServices
{
    public interface IMainFieldService
    {
        Task<List<MainFieldDto>> GetAllAsync();
        Task UpdateAsync(List<MainFieldDto> Dto);
    }
}
