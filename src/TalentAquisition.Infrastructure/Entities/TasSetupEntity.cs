using System;
using System.Collections.Generic;

namespace TalentAquisition.Infrastructure.Entities;

public partial class TasSetupEntity
{
    public int Id { get; set; }

    public int ChannelId { get; set; }

    public int HiringManagerId { get; set; }

    public string EntityName { get; set; } = null!;

    public string? Address { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public string? Ipaddress { get; set; }

    public string? Macaddress { get; set; }
}
