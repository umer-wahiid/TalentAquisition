using System;
using System.Collections.Generic;

namespace TalentAquisition.Infrastructure.Entities;

public partial class TasMainLeadCompensation
{
    public int CompensationId { get; set; }

    public int EmployeeId { get; set; }

    public int CompensationTypeId { get; set; }

    public string PayType { get; set; } = null!;

    public decimal Amount { get; set; }

    public string? StructureType { get; set; }

    public int? RetroactiveStructure { get; set; }

    public bool InclusiveOfOthers { get; set; }

    public string? TierCriteria { get; set; }

    public bool IsDeleted { get; set; }

    public int CreatedBy { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual TasSetupRetroactiveStructure? RetroactiveStructureNavigation { get; set; }
}
