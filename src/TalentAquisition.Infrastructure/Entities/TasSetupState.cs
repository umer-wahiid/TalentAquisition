using System;
using System.Collections.Generic;

namespace TalentAquisition.Infrastructure.Entities;

public partial class TasSetupState
{
    public int Id { get; set; }

    public string? StateName { get; set; }

    public string? StateFullName { get; set; }

    public bool? IsDeleted { get; set; }

    public int? CreatedBy { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<TasMainEmployee> TasMainEmployeeResidesIns { get; set; } = new List<TasMainEmployee>();

    public virtual ICollection<TasMainEmployee> TasMainEmployeeStateId2Navigations { get; set; } = new List<TasMainEmployee>();

    public virtual ICollection<TasMainEmployee> TasMainEmployeeStates { get; set; } = new List<TasMainEmployee>();
}
