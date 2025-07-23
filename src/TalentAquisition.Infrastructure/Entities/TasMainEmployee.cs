using System;
using System.Collections.Generic;

namespace TalentAquisition.Infrastructure.Entities;

public partial class TasMainEmployee
{
    public int EmployeeId { get; set; }

    public DateTime? EstimatedStartDate { get; set; }

    public int? EmployeeTypeId { get; set; }

    public int? TypeId { get; set; }

    public int? CurrentCompanyId { get; set; }

    public int? DepartmentId { get; set; }

    public int? EmploymentStatusId { get; set; }

    public int? JobTitleId { get; set; }

    public bool IsSeasonalEmployee { get; set; }

    public bool IsRemote { get; set; }

    public int? RoleTypeId { get; set; }

    public bool IsRehire { get; set; }

    public bool HasNmlsLicense { get; set; }

    public string? NmlsId { get; set; }

    public string? NmlsFirstName { get; set; }

    public string? NmlsLastName { get; set; }

    public int? BranchId { get; set; }

    public int? ManagerId { get; set; }

    public bool IsTempAuthorityNeeded { get; set; }

    public string? HasPreventions { get; set; }

    public bool IsRealtorLicense { get; set; }

    public string? LicensedStates { get; set; }

    public bool WillActivelyContinue { get; set; }

    public string? RealStateCompany { get; set; }

    public bool HasBonus { get; set; }

    public int? BonusTypeId { get; set; }

    public string? AdditionalNotes { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string FullName { get; set; } = null!;

    public bool HasPreferredName { get; set; }

    public string? PreferredFirstName { get; set; }

    public string? PreferredLastName { get; set; }

    public string Email { get; set; } = null!;

    public string? CellPhone { get; set; }

    public int? ResidesInId { get; set; }

    public string? StreetAddress { get; set; }

    public string? City { get; set; }

    public int? StateId { get; set; }

    public string? ZipCode { get; set; }

    public string? AddressLine2 { get; set; }

    public bool HasOtherAddress { get; set; }

    public string? StreetAddress2 { get; set; }

    public string? City2 { get; set; }

    public int? StateId2 { get; set; }

    public string? ZipCode2 { get; set; }

    public string? Resume { get; set; }

    public int? SalaryTypeId { get; set; }

    public bool HasSignonBonus { get; set; }

    public decimal? SignonBonusAmount { get; set; }

    public bool IsSignonBonusRecoverable { get; set; }

    public int? RecoverableTimeFrameId { get; set; }

    public string? CompensationNotes1 { get; set; }

    public bool HasGuarantee { get; set; }

    public bool IsSalaryRecoverable { get; set; }

    public decimal? MinTransaction { get; set; }

    public decimal? MaxTransaction { get; set; }

    public string? CompensationNotes2 { get; set; }

    public string? LeadSourceNotes { get; set; }

    public bool IsRecoveryGuaranteed { get; set; }

    public decimal? AmountPerMonth { get; set; }

    public string? Month { get; set; }

    public bool IsGreaterOfComp { get; set; }

    public bool IsInclusiveOfSalary { get; set; }

    public int? PaymentDateId { get; set; }

    public int? LaptopId { get; set; }

    public bool HasDockingStation { get; set; }

    public int? MonitorId { get; set; }

    public bool HasKeyboardMouse { get; set; }

    public int? ZoomOptionId { get; set; }

    public string? PreferredAreaCode { get; set; }

    public string? IsFaxToMail { get; set; }

    public int? ShippingAddressId { get; set; }

    public string? OtherAddress { get; set; }

    public bool AreTermsAcknowledged { get; set; }

    public string? Picture { get; set; }

    public string? LinkedIn { get; set; }

    public int? LeadSourceId { get; set; }

    public int? StatusId { get; set; }

    public string? Reference { get; set; }

    public decimal? Volume { get; set; }

    public int? LendingFootprintId { get; set; }

    public int? HierarchyId { get; set; }

    public string? Ownership { get; set; }

    public string? TrackingDoc { get; set; }

    public string? PricingDoc { get; set; }

    public string? ProformaDoc { get; set; }

    public string? UniqueProductsRequest { get; set; }

    public string? Gifts { get; set; }

    public string? ActionItems { get; set; }

    public DateTime? LastTouch { get; set; }

    public bool IsFormerEmployee { get; set; }

    public bool IsUnfollow { get; set; }

    public bool IsCompleted { get; set; }

    public bool IsDeleted { get; set; }

    public int CreatedBy { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual TasSetupBonusType? BonusType { get; set; }

    public virtual TasSetupBranch? Branch { get; set; }

    public virtual TasSetupCurrentcompany? CurrentCompany { get; set; }

    public virtual TasSetupDepartment? Department { get; set; }

    public virtual TasSetupEmployeeType? EmployeeType { get; set; }

    public virtual TasSetupEmploymentStatus? EmploymentStatus { get; set; }

    public virtual TasSetupHierarchy? Hierarchy { get; set; }

    public virtual TasSetupJobTitle? JobTitle { get; set; }

    public virtual TasSetupLaptop? Laptop { get; set; }

    public virtual TasMainUser? LeadSource { get; set; }

    public virtual TasSetupManager? Manager { get; set; }

    public virtual TasSetupMonitor? Monitor { get; set; }

    public virtual TasSetupPaymentDate? PaymentDate { get; set; }

    public virtual TasSetupRecoverableTimeFrame? RecoverableTimeFrame { get; set; }

    public virtual TasSetupState? ResidesIn { get; set; }

    public virtual TasSetupSalaryType? SalaryType { get; set; }

    public virtual TasSetupShippingAddress? ShippingAddress { get; set; }

    public virtual TasSetupState? State { get; set; }

    public virtual TasSetupState? StateId2Navigation { get; set; }

    public virtual TasSetupStatus? Status { get; set; }

    public virtual TasSetupType? Type { get; set; }

    public virtual TasSetupZoomOption? ZoomOption { get; set; }
}
