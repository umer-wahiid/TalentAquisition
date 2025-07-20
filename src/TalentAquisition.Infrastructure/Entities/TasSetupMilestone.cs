using System;
using System.Collections.Generic;

namespace TalentAquisition.Infrastructure.Entities;

public partial class TasSetupMilestone
{
    public int MilestoneId { get; set; }

    public string? MilestoneName { get; set; }

    public bool? IsDeleted { get; set; }
}
