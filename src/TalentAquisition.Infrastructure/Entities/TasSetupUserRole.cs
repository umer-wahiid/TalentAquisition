using System;
using System.Collections.Generic;

namespace TalentAquisition.Infrastructure.Entities;

public partial class TasSetupUserRole
{
    public int Id { get; set; }

    public string? RoleName { get; set; }

    public bool IsActive { get; set; }

    public bool OnlySelfRecord { get; set; }

    public bool SubmitOffer { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? Created { get; set; }

    public int? UpdateBy { get; set; }

    public DateTime? Updated { get; set; }

    public int? DeletedBy { get; set; }

    public DateTime? Deleted { get; set; }
}
