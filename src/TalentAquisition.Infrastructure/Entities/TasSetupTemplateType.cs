using System;
using System.Collections.Generic;

namespace TalentAquisition.Infrastructure.Entities;

public partial class TasSetupTemplateType
{
    public int Id { get; set; }

    public string TemplateName { get; set; } = null!;

    public string? Description { get; set; }

    public bool IsActive { get; set; }

    public bool? IsDeleted { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public string? Ipaddress { get; set; }

    public string? Macaddress { get; set; }

    public bool IsSms { get; set; }

    public virtual ICollection<TasMainEmailTemplate> TasMainEmailTemplates { get; set; } = new List<TasMainEmailTemplate>();
}
