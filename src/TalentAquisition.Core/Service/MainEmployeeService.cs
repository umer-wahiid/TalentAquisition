using TalentAquisition.Core.Dtos;
using TalentAquisition.Core.IServices;
using TalentAquisition.Core.IRepositories;

namespace TalentAquisition.Infrastructure.Repositories
{
    public class MainEmployeeService : IMainEmployeeService
    {
        public IMainEmployeeRepository _mainEmployeeRepository { get; set; }
        public MainEmployeeService(IMainEmployeeRepository mainEmployeeRepository)
        {
            _mainEmployeeRepository = mainEmployeeRepository;
        }

        public async Task<Response<IEnumerable<dynamic>>> GetAllAsync()
        {
            return await _mainEmployeeRepository.GetAllAsync();
        }
    }
}