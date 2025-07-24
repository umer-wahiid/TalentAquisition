using TalentAquisition.Core.Dtos;

namespace TalentAquisition.Core.IRepositories
{
    public interface IMainFieldRepository
    {
        Task<Response<IEnumerable<MainFieldDto>>> GetAllAsync();
        Task<Response<bool>> UpdateAsync(List<MainFieldDto> dto);
    }
}