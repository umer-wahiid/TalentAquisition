using Microsoft.EntityFrameworkCore;
using TalentAquisition.Core.Dtos;
using TalentAquisition.Core.IRepositories;
using TalentAquisition.Infrastructure.Context;
using TalentAquisition.Infrastructure.Extensions.Mappings;

namespace TalentAquisition.Infrastructure.Repositories
{
    public class SetupStatusRepository : ISetupStatusRepository
    {
        private readonly TalentAquisitionDbContext _context;

        public SetupStatusRepository(TalentAquisitionDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(SetupStatusDto dto)
        {
            var entity = dto.ToEntity();
            await _context.TasSetupStatuses.AddAsync(entity);
            await _context.SaveChangesAsync();
            dto.StatusId = entity.StatusId;
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.TasSetupStatuses.FindAsync(id);
            if (entity != null)
            {
                entity.IsDeleted = true;
                entity.UpdatedAt = DateTime.UtcNow;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<SetupStatusDto>> GetAllAsync()
        {
            return await _context.TasSetupStatuses
                .Where(s => !(s.IsDeleted ?? false))
                .Select(s => s.ToDto())
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<SetupStatusDto> GetByIdAsync(int id)
        {
            var entity = await _context.TasSetupStatuses.FindAsync(id);
            return entity?.ToDto();
        }

        public async Task UpdateAsync(SetupStatusDto dto)
        {
            var entity = await _context.TasSetupStatuses.FindAsync(dto.StatusId);
            if (entity != null)
            {
                entity.Name = dto.Name;
                entity.UpdatedAt = DateTime.UtcNow;
                await _context.SaveChangesAsync();
            }
        }
    }
}
