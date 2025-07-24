using Microsoft.EntityFrameworkCore;
using TalentAquisition.Core.Dtos;
using TalentAquisition.Core.IRepositories;
using TalentAquisition.Infrastructure.Context;
using TalentAquisition.Infrastructure.Extensions.Mappings;

namespace TalentAquisition.Infrastructure.Repositories
{
    public class MainFieldRepository : IMainFieldRepository
    {
        private readonly TalentAquisitionDbContext _context;

        public MainFieldRepository(TalentAquisitionDbContext context)
        {
            _context = context;
        }

        public async Task<Response<IEnumerable<MainFieldDto>>> GetAllAsync()
        {
            try
            {
                var result = await _context.TasMainFields
                    .Where(s => !s.IsDeleted)
                    .Select(s => s.ToDto())
                    .ToListAsync();

                return Response<IEnumerable<MainFieldDto>>.SuccessResult(result, "");
            }
            catch (Exception ex)
            {
                return Response<IEnumerable<MainFieldDto>>.FailureResult(
                    "An error occurred while retrieving fields",
                    ex);
            }
        }

        public async Task<Response<bool>> UpdateAsync(List<MainFieldDto> dtos)
        {
            try
            {
                var ids = dtos.Select(d => d.FieldId).ToList();

                var existingEntities = await _context.TasMainFields
                    .Where(e => ids.Contains(e.FieldId))
                    .ToDictionaryAsync(e => e.FieldId);

                foreach (var dto in dtos)
                {
                    if (existingEntities.TryGetValue(dto.FieldId, out var entity))
                    {
                        if (entity.MilestoneIdBranch != dto.MilestoneIdBranch || entity.MilestoneId != dto.MilestoneId)
                        {
                            entity.MilestoneIdBranch = dto.MilestoneIdBranch;
                            entity.MilestoneId = dto.MilestoneId;
                        }
                    }
                    else
                    {
                        throw new KeyNotFoundException($"TasMainField with ID {dto.FieldId} not found");
                    }
                }

                await _context.SaveChangesAsync();

                return Response<bool>.SuccessResult(true, "Fields updated successfully");
            }
            catch (Exception ex)
            {
                return Response<bool>.FailureResult("Failed to update fields", ex);
            }
        }
    }
}
