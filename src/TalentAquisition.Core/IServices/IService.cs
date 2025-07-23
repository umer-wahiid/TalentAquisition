using TalentAquisition.Core.Dtos;

namespace TalentAquisition.Core.IServices
{
    public interface IService<T> where T : class
    {
        Task<Response<IEnumerable<T>>> GetAllAsync();
        Task<Response<T>> GetByIdAsync(int id);
        Task<Response<int>> AddAsync(T entity);
        Task<Response<bool>> UpdateAsync(T entity);
        Task<Response<bool>> DeleteAsync(int id);
    }
}
