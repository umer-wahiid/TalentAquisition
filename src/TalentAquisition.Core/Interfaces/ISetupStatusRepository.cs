using TalentAquisition.Core.DTOs;

namespace TalentAquisition.Core.Interfaces
{
    public interface ISetupStatusRepository : IRepository<SetupStatusDto>
    {
        Task<IEnumerable<SetupStatusDto>> GetActiveStatusesAsync();
    }
}
