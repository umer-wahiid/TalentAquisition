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

        public async Task<Response<int>> AddAsync(SetupStatusDto dto)
        {
            try
            {
                var entity = dto.ToEntity();
                await _context.TasSetupStatuses.AddAsync(entity);
                await _context.SaveChangesAsync();
                return Response<int>.SuccessResult(entity.StatusId, "Status created successfully");
            }
            catch (Exception ex)
            {
                return Response<int>.FailureResult("Failed to create status", ex);
            }
        }

        public async Task<Response<bool>> DeleteAsync(int id)
        {
            var entity = await _context.TasSetupStatuses.FindAsync(id);
            if (entity != null)
            {
                entity.IsDeleted = true;
                entity.UpdatedAt = DateTime.UtcNow;
                await _context.SaveChangesAsync();
                return Response<bool>.SuccessResult(true, "Status deleted successfully");
            }
            else
            {
                return Response<bool>.SuccessResult(false, "Status not found");
            }
        }

        public async Task<Response<IEnumerable<SetupStatusDto>>> GetAllAsync()
        {
            try
            {
                var statuses = await _context.TasSetupStatuses
                    .Where(s => !(s.IsDeleted ?? false))
                    .Select(s => s.ToDto())
                    .AsNoTracking()
                    .ToListAsync();

                return Response<IEnumerable<SetupStatusDto>>.SuccessResult(statuses, "");
            }
            catch (Exception ex)
            {
                return Response<IEnumerable<SetupStatusDto>>.FailureResult(
                    "An error occurred while retrieving statuses",
                    ex);
            }
        }

        public async Task<Response<SetupStatusDto>> GetByIdAsync(int id)
        {
            try
            {
                var entity = await _context.TasSetupStatuses.FindAsync(id);
                if (entity == null || entity.IsDeleted == true)
                    return Response<SetupStatusDto>.FailureResult("Status not found");

                return Response<SetupStatusDto>.SuccessResult(entity.ToDto());
            }
            catch (Exception ex)
            {
                return Response<SetupStatusDto>.FailureResult("Database error", ex);
            }
        }

        public async Task<Response<bool>> UpdateAsync(SetupStatusDto dto)
        {
            try
            {
                var entity = await _context.TasSetupStatuses.FindAsync(dto.StatusId);
                if (entity == null)
                    return Response<bool>.FailureResult("Status not found");

                entity.Name = dto.Name;
                entity.UpdatedAt = DateTime.UtcNow;
                await _context.SaveChangesAsync();

                return Response<bool>.SuccessResult(true, "Status updated successfully");
            }
            catch (Exception ex)
            {
                return Response<bool>.FailureResult("Failed to update status", ex);
            }
        }
    }
}
