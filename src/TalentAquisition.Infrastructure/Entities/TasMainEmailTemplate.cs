using System;
using System.Collections.Generic;

namespace TalentAquisition.Infrastructure.Entities;

public partial class TasMainEmailTemplate
{
    public int TemplateId { get; set; }

    public int EntityId { get; set; }

    public int TemplateFor { get; set; }

    public string? Subject { get; set; }

    public string? Body { get; set; }

    public string? SendTo { get; set; }

    public string? Bcc { get; set; }

    public string? Cc { get; set; }

    public bool IsDefault { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedTime { get; set; }

    public string? Ipaddress { get; set; }

    public string? Macaddress { get; set; }

    public bool IsSms { get; set; }

    public virtual TasSetupTemplateType TemplateForNavigation { get; set; } = null!;
}
