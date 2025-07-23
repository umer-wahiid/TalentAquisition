namespace TalentAquisition.Core.Dtos
{
    public class MainFieldDto
    {
        public int FieldId { get; set; }

        public string? FieldName { get; set; }

        public string FieldIdentifier { get; set; } = null!;

        public int? MilestoneId { get; set; }

        public string? Description { get; set; }

        public string? DataType { get; set; }

        public bool IsDeleted { get; set; }

        public int? TabId { get; set; }

        public int? MilestoneIdBranch { get; set; }
    }
}
