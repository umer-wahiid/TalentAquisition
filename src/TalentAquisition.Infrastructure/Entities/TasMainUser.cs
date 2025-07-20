using System;
using System.Collections.Generic;

namespace TalentAquisition.Infrastructure.Entities;

public partial class TasMainUser
{
    public int UserId { get; set; }

    public int? ModuleId { get; set; }

    public int? RoleId { get; set; }

    public string? UserName { get; set; }

    public string? UserPassword { get; set; }

    public string? FullName { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public bool Active { get; set; }

    public bool IsBranchRestrict { get; set; }

    public int? TransId { get; set; }

    public bool? IsDeleted { get; set; }

    public int? CreateBy { get; set; }

    public int? UpdateBy { get; set; }

    public DateTime? CreateDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public string? AllowedRecords { get; set; }

    public string? AllowedRecordIds { get; set; }

    public bool IsLead { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Code { get; set; }

    public int? JobTitleId { get; set; }

    public int? BranchId { get; set; }

    public int? EntityId { get; set; }

    public string? Job { get; set; }
}
