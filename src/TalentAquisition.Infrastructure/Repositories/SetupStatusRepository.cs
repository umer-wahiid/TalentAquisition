using Microsoft.EntityFrameworkCore;
using TalentAquisition.Core.DTOs;
using TalentAquisition.Core.Interfaces;
using TalentAquisition.Infrastructure.Context;
using TalentAquisition.Infrastructure.Entities;

namespace TalentAquisition.Infrastructure.Repositories
{
    public class SetupStatusRepository : ISetupStatusRepository
    {
        private readonly TalentAquisitionDbContext _context;

        public SetupStatusRepository(TalentAquisitionDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(SetupStatusDto entity)
        {
            var dbEntity = new TasSetupStatus
            {
                Name = entity.Name,
                CreatedAt = DateTime.UtcNow,
                IsDeleted = false
            };

            await _context.TasSetupStatuses.AddAsync(dbEntity);
            await _context.SaveChangesAsync();

            entity.StatusId = dbEntity.StatusId;
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
                .Select(s => new SetupStatusDto
                {
                    StatusId = s.StatusId,
                    Name = s.Name,
                    CreatedAt = s.CreatedAt,
                    UpdatedAt = s.UpdatedAt,
                    IsDeleted = s.IsDeleted
                }).ToListAsync();
        }

        public async Task<SetupStatusDto> GetByIdAsync(int id)
        {
            var entity = await _context.TasSetupStatuses.FindAsync(id);
            if (entity == null || entity.IsDeleted == true) return null;

            return new SetupStatusDto
            {
                StatusId = entity.StatusId,
                Name = entity.Name,
                CreatedAt = entity.CreatedAt,
                UpdatedAt = entity.UpdatedAt,
                IsDeleted = entity.IsDeleted
            };
        }

        public async Task UpdateAsync(SetupStatusDto entity)
        {
            var dbEntity = await _context.TasSetupStatuses.FindAsync(entity.StatusId);
            if (dbEntity != null)
            {
                dbEntity.Name = entity.Name;
                dbEntity.UpdatedAt = DateTime.UtcNow;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<SetupStatusDto>> GetActiveStatusesAsync()
        {
            return await _context.TasSetupStatuses
                .Where(s => !(s.IsDeleted ?? false))
                .Select(s => new SetupStatusDto
                {
                    StatusId = s.StatusId,
                    Name = s.Name
                })
                .ToListAsync();
        }
    }
}
