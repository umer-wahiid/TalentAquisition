using TalentAquisition.Core.Dtos;

namespace TalentAquisition.Core.IRepositories
{
    public interface IMainEmployeeRepository
    {
        Task<Response<IEnumerable<dynamic>>> GetAllAsync();
    }
}
