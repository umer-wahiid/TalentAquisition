namespace TalentAquisition.Core.DTOs
{
    public class SetupStatusDto
    {
        public int StatusId { get; set; }
        public string Name { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
