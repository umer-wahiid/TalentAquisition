using TalentAquisition.Core.Dtos;

namespace TalentAquisition.Core.IServices
{
    public interface IMainEmployeeService
    {
        Task<Response<IEnumerable<dynamic>>> GetAllAsync();
    }
}
