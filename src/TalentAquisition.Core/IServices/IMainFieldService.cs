using TalentAquisition.Core.Dtos;

namespace TalentAquisition.Core.IServices
{
    public interface IMainFieldService
    {
        Task<Response<IEnumerable<MainFieldDto>>> GetAllAsync();
        Task<Response<bool>> UpdateAsync(List<MainFieldDto> dto);
    }
}
