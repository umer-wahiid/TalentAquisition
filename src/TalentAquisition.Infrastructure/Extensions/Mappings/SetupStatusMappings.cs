using TalentAquisition.Core.Dtos;
using TalentAquisition.Infrastructure.Entities;

namespace TalentAquisition.Infrastructure.Extensions.Mappings
{
    public static class SetupStatusMappings
    {
        public static TasSetupStatus ToEntity(this SetupStatusDto dto)
        {
            return new TasSetupStatus
            {
                StatusId = dto.StatusId,
                Name = dto.Name,
                CreatedAt = dto.StatusId == 0 ? DateTime.UtcNow : dto.CreatedAt,
                UpdatedAt = DateTime.UtcNow,
                IsDeleted = dto.IsDeleted
            };
        }

        public static SetupStatusDto ToDto(this TasSetupStatus entity)
        {
            if (entity == null) return null;

            return new SetupStatusDto
            {
                StatusId = entity.StatusId,
                Name = entity.Name,
                CreatedAt = entity.CreatedAt,
                UpdatedAt = entity.UpdatedAt,
                IsDeleted = entity.IsDeleted
            };
        }
    }
}
