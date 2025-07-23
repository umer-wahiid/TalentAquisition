using TalentAquisition.Core.Dtos;
using TalentAquisition.Infrastructure.Entities;

namespace TalentAquisition.Infrastructure.Extensions.Mappings
{
    public static class MainFieldMappings
    {
        public static TasMainField ToEntity(this MainFieldDto dto)
        {
            return new TasMainField
            {
                FieldId = dto. FieldId,
                FieldName = dto. FieldName,
                FieldIdentifier = dto. FieldIdentifier,
                MilestoneId = dto. MilestoneId,
                Description = dto. Description,
                DataType = dto. DataType,
                IsDeleted = dto. IsDeleted,
                TabId = dto. TabId,
                MilestoneIdBranch = dto.MilestoneIdBranch
            };
        }

        public static MainFieldDto ToDto(this TasMainField entity)
        {
            if (entity == null) return null;

            return new MainFieldDto
            {
                FieldId = entity.FieldId,
                FieldName = entity.FieldName,
                FieldIdentifier = entity.FieldIdentifier,
                MilestoneId = entity.MilestoneId,
                Description = entity.Description,
                DataType = entity.DataType,
                IsDeleted = entity.IsDeleted,
                TabId = entity.TabId,
                MilestoneIdBranch = entity.MilestoneIdBranch
            };
        }
    }
}
