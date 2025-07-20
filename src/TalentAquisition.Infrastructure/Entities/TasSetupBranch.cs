using System;
using System.Collections.Generic;

namespace TalentAquisition.Infrastructure.Entities;

public partial class TasSetupBranch
{
    public int Id { get; set; }

    public int EntityId { get; set; }

    public int BranchManagerId { get; set; }

    public string BranchCode { get; set; } = null!;

    public string BranchName { get; set; } = null!;

    public string? State { get; set; }

    public string? City { get; set; }

    public string? ZipCode { get; set; }

    public string? Phone { get; set; }

    public DateTime? TerminationDate { get; set; }

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
