using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TalentAquisition.Infrastructure.Entities;

namespace TalentAquisition.Infrastructure.Context;

public partial class TalentAquisitionDbContext : DbContext
{
    public TalentAquisitionDbContext()
    {
    }

    public TalentAquisitionDbContext(DbContextOptions<TalentAquisitionDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TasConfigSmtp> TasConfigSmtps { get; set; }

    public virtual DbSet<TasMainEmailTemplate> TasMainEmailTemplates { get; set; }

    public virtual DbSet<TasMainEmployee> TasMainEmployees { get; set; }

    public virtual DbSet<TasMainField> TasMainFields { get; set; }

    public virtual DbSet<TasMainLeadCompensation> TasMainLeadCompensations { get; set; }

    public virtual DbSet<TasMainNote> TasMainNotes { get; set; }

    public virtual DbSet<TasMainUser> TasMainUsers { get; set; }

    public virtual DbSet<TasObEmployee> TasObEmployees { get; set; }

    public virtual DbSet<TasObOnboardingTask> TasObOnboardingTasks { get; set; }

    public virtual DbSet<TasObOnboardingTaskCategory> TasObOnboardingTaskCategories { get; set; }

    public virtual DbSet<TasSetupBonusType> TasSetupBonusTypes { get; set; }

    public virtual DbSet<TasSetupBranch> TasSetupBranches { get; set; }

    public virtual DbSet<TasSetupChannel> TasSetupChannels { get; set; }

    public virtual DbSet<TasSetupCommunicationMethod> TasSetupCommunicationMethods { get; set; }

    public virtual DbSet<TasSetupCompensationType> TasSetupCompensationTypes { get; set; }

    public virtual DbSet<TasSetupCurrentcompany> TasSetupCurrentcompanies { get; set; }

    public virtual DbSet<TasSetupDepartment> TasSetupDepartments { get; set; }

    public virtual DbSet<TasSetupEmployeeType> TasSetupEmployeeTypes { get; set; }

    public virtual DbSet<TasSetupEmploymentStatus> TasSetupEmploymentStatuses { get; set; }

    public virtual DbSet<TasSetupEntity> TasSetupEntities { get; set; }

    public virtual DbSet<TasSetupHierarchy> TasSetupHierarchies { get; set; }

    public virtual DbSet<TasSetupJobTitle> TasSetupJobTitles { get; set; }

    public virtual DbSet<TasSetupLaptop> TasSetupLaptops { get; set; }

    public virtual DbSet<TasSetupManager> TasSetupManagers { get; set; }

    public virtual DbSet<TasSetupMilestone> TasSetupMilestones { get; set; }

    public virtual DbSet<TasSetupMonitor> TasSetupMonitors { get; set; }

    public virtual DbSet<TasSetupPaymentDate> TasSetupPaymentDates { get; set; }

    public virtual DbSet<TasSetupRecoverableTimeFrame> TasSetupRecoverableTimeFrames { get; set; }

    public virtual DbSet<TasSetupRetroactiveStructure> TasSetupRetroactiveStructures { get; set; }

    public virtual DbSet<TasSetupSalaryType> TasSetupSalaryTypes { get; set; }

    public virtual DbSet<TasSetupShippingAddress> TasSetupShippingAddresses { get; set; }

    public virtual DbSet<TasSetupState> TasSetupStates { get; set; }

    public virtual DbSet<TasSetupStatus> TasSetupStatuses { get; set; }

    public virtual DbSet<TasSetupTemplateType> TasSetupTemplateTypes { get; set; }

    public virtual DbSet<TasSetupType> TasSetupTypes { get; set; }

    public virtual DbSet<TasSetupUserRole> TasSetupUserRoles { get; set; }

    public virtual DbSet<TasSetupZoomOption> TasSetupZoomOptions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-LMV5DEC;Integrated Security=true;Initial Catalog=TalentAquisition;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TasConfigSmtp>(entity =>
        {
            entity.HasKey(e => e.Id)
                .HasName("PK__TAS_Smtp__3213E83F126B15DD")
                .HasFillFactor(90);

            entity.ToTable("tas_config_smtp");

            entity.HasIndex(e => e.Id, "NonClusteredIndex-20180411-153050");

            entity.Property(e => e.Id).HasColumnName("id");
        });

        modelBuilder.Entity<TasMainEmailTemplate>(entity =>
        {
            entity.HasKey(e => e.TemplateId).HasName("PK_TAS_Setup_EmailTemplate");

            entity.ToTable("tas_main_email_template");

            entity.Property(e => e.TemplateId).HasColumnName("TemplateID");
            entity.Property(e => e.Bcc)
                .HasMaxLength(225)
                .IsUnicode(false)
                .HasColumnName("BCC");
            entity.Property(e => e.Body).IsUnicode(false);
            entity.Property(e => e.Cc)
                .HasMaxLength(225)
                .IsUnicode(false)
                .HasColumnName("CC");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.EntityId).HasColumnName("EntityID");
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(225)
                .IsUnicode(false)
                .HasColumnName("IPAddress");
            entity.Property(e => e.Macaddress)
                .HasMaxLength(225)
                .IsUnicode(false)
                .HasColumnName("MACAddress");
            entity.Property(e => e.SendTo)
                .HasMaxLength(225)
                .IsUnicode(false);
            entity.Property(e => e.Subject)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedTime).HasColumnType("datetime");

            entity.HasOne(d => d.TemplateForNavigation).WithMany(p => p.TasMainEmailTemplates)
                .HasForeignKey(d => d.TemplateFor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TAS_Setup_EmailTemplate_TAS_Setup_EmailTemplatesTypes");
        });

        modelBuilder.Entity<TasMainEmployee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PK__tas_main__C134C9C13B6CDF2F");

            entity.ToTable("tas_main_employee");

            entity.Property(e => e.EmployeeId).HasColumnName("employeeId");
            entity.Property(e => e.ActionItems)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("actionItems");
            entity.Property(e => e.AdditionalNotes)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("additionalNotes");
            entity.Property(e => e.AddressLine2)
                .HasMaxLength(225)
                .IsUnicode(false)
                .HasColumnName("addressLine2");
            entity.Property(e => e.AmountPerMonth)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("amountPerMonth");
            entity.Property(e => e.AreTermsAcknowledged).HasColumnName("areTermsAcknowledged");
            entity.Property(e => e.BonusTypeId).HasColumnName("bonusTypeId");
            entity.Property(e => e.BranchId).HasColumnName("branchId");
            entity.Property(e => e.CellPhone)
                .HasMaxLength(225)
                .IsUnicode(false)
                .HasColumnName("cellPhone");
            entity.Property(e => e.City)
                .HasMaxLength(225)
                .IsUnicode(false)
                .HasColumnName("city");
            entity.Property(e => e.City2)
                .HasMaxLength(225)
                .IsUnicode(false)
                .HasColumnName("city2");
            entity.Property(e => e.CompensationNotes1)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("compensationNotes1");
            entity.Property(e => e.CompensationNotes2)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("compensationNotes2");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.CreatedBy).HasColumnName("createdBy");
            entity.Property(e => e.CurrentCompanyId).HasColumnName("currentCompanyId");
            entity.Property(e => e.DepartmentId).HasColumnName("departmentId");
            entity.Property(e => e.Email)
                .HasMaxLength(225)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.EmployeeTypeId).HasColumnName("employeeTypeId");
            entity.Property(e => e.EmploymentStatusId).HasColumnName("employmentStatusId");
            entity.Property(e => e.EstimatedStartDate)
                .HasColumnType("datetime")
                .HasColumnName("estimatedStartDate");
            entity.Property(e => e.FirstName)
                .HasMaxLength(225)
                .IsUnicode(false)
                .HasColumnName("firstName");
            entity.Property(e => e.FullName)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("fullName");
            entity.Property(e => e.Gifts)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("gifts");
            entity.Property(e => e.HasBonus).HasColumnName("hasBonus");
            entity.Property(e => e.HasDockingStation).HasColumnName("hasDockingStation");
            entity.Property(e => e.HasGuarantee).HasColumnName("hasGuarantee");
            entity.Property(e => e.HasKeyboardMouse).HasColumnName("hasKeyboardMouse");
            entity.Property(e => e.HasNmlsLicense).HasColumnName("hasNmlsLicense");
            entity.Property(e => e.HasOtherAddress).HasColumnName("hasOtherAddress");
            entity.Property(e => e.HasPreferredName).HasColumnName("hasPreferredName");
            entity.Property(e => e.HasPreventions)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("hasPreventions");
            entity.Property(e => e.HasSignonBonus).HasColumnName("hasSignonBonus");
            entity.Property(e => e.HierarchyId).HasColumnName("hierarchyId");
            entity.Property(e => e.IsCompleted).HasColumnName("isCompleted");
            entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");
            entity.Property(e => e.IsFaxToMail)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("isFaxToMail");
            entity.Property(e => e.IsFormerEmployee).HasColumnName("isFormerEmployee");
            entity.Property(e => e.IsGreaterOfComp).HasColumnName("isGreaterOfComp");
            entity.Property(e => e.IsInclusiveOfSalary).HasColumnName("isInclusiveOfSalary");
            entity.Property(e => e.IsRealtorLicense).HasColumnName("isRealtorLicense");
            entity.Property(e => e.IsRecoveryGuaranteed).HasColumnName("isRecoveryGuaranteed");
            entity.Property(e => e.IsRehire).HasColumnName("isRehire");
            entity.Property(e => e.IsRemote).HasColumnName("isRemote");
            entity.Property(e => e.IsSalaryRecoverable).HasColumnName("isSalaryRecoverable");
            entity.Property(e => e.IsSeasonalEmployee).HasColumnName("isSeasonalEmployee");
            entity.Property(e => e.IsSignonBonusRecoverable).HasColumnName("isSignonBonusRecoverable");
            entity.Property(e => e.IsTempAuthorityNeeded).HasColumnName("isTempAuthorityNeeded");
            entity.Property(e => e.IsUnfollow).HasColumnName("isUnfollow");
            entity.Property(e => e.JobTitleId).HasColumnName("jobTitleId");
            entity.Property(e => e.LaptopId).HasColumnName("laptopId");
            entity.Property(e => e.LastName)
                .HasMaxLength(225)
                .IsUnicode(false)
                .HasColumnName("lastName");
            entity.Property(e => e.LastTouch)
                .HasColumnType("datetime")
                .HasColumnName("lastTouch");
            entity.Property(e => e.LeadSourceId).HasColumnName("leadSourceId");
            entity.Property(e => e.LeadSourceNotes)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("leadSourceNotes");
            entity.Property(e => e.LendingFootprintId).HasColumnName("lendingFootprintId");
            entity.Property(e => e.LicensedStates)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("licensedStates");
            entity.Property(e => e.LinkedIn)
                .HasMaxLength(2500)
                .IsUnicode(false)
                .HasColumnName("linkedIn");
            entity.Property(e => e.ManagerId).HasColumnName("managerId");
            entity.Property(e => e.MaxTransaction)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("maxTransaction");
            entity.Property(e => e.MinTransaction)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("minTransaction");
            entity.Property(e => e.MonitorId).HasColumnName("monitorId");
            entity.Property(e => e.Month)
                .HasMaxLength(225)
                .IsUnicode(false)
                .HasColumnName("month");
            entity.Property(e => e.NmlsFirstName)
                .HasMaxLength(225)
                .IsUnicode(false)
                .HasColumnName("nmlsFirstName");
            entity.Property(e => e.NmlsId)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("nmlsId");
            entity.Property(e => e.NmlsLastName)
                .HasMaxLength(225)
                .IsUnicode(false)
                .HasColumnName("nmlsLastName");
            entity.Property(e => e.OtherAddress)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("otherAddress");
            entity.Property(e => e.Ownership)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ownership");
            entity.Property(e => e.PaymentDateId).HasColumnName("paymentDateId");
            entity.Property(e => e.Picture)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("picture");
            entity.Property(e => e.PreferredAreaCode)
                .HasMaxLength(225)
                .IsUnicode(false)
                .HasColumnName("preferredAreaCode");
            entity.Property(e => e.PreferredFirstName)
                .HasMaxLength(225)
                .IsUnicode(false)
                .HasColumnName("preferredFirstName");
            entity.Property(e => e.PreferredLastName)
                .HasMaxLength(225)
                .IsUnicode(false)
                .HasColumnName("preferredLastName");
            entity.Property(e => e.PricingDoc)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("pricingDoc");
            entity.Property(e => e.ProformaDoc)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("proformaDoc");
            entity.Property(e => e.RealStateCompany)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("realStateCompany");
            entity.Property(e => e.RecoverableTimeFrameId).HasColumnName("recoverableTimeFrameId");
            entity.Property(e => e.Reference)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("reference");
            entity.Property(e => e.ResidesInId).HasColumnName("residesInId");
            entity.Property(e => e.Resume)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("resume");
            entity.Property(e => e.RoleTypeId).HasColumnName("roleTypeId");
            entity.Property(e => e.SalaryTypeId).HasColumnName("salaryTypeId");
            entity.Property(e => e.ShippingAddressId).HasColumnName("shippingAddressId");
            entity.Property(e => e.SignonBonusAmount)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("signonBonusAmount");
            entity.Property(e => e.StateId).HasColumnName("stateId");
            entity.Property(e => e.StateId2).HasColumnName("stateId2");
            entity.Property(e => e.StatusId).HasColumnName("statusId");
            entity.Property(e => e.StreetAddress)
                .HasMaxLength(225)
                .IsUnicode(false)
                .HasColumnName("streetAddress");
            entity.Property(e => e.StreetAddress2)
                .HasMaxLength(225)
                .IsUnicode(false)
                .HasColumnName("streetAddress2");
            entity.Property(e => e.TrackingDoc)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("trackingDoc");
            entity.Property(e => e.TypeId).HasColumnName("typeId");
            entity.Property(e => e.UniqueProductsRequest)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("uniqueProductsRequest");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updatedAt");
            entity.Property(e => e.UpdatedBy).HasColumnName("updatedBy");
            entity.Property(e => e.Volume)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("volume");
            entity.Property(e => e.WillActivelyContinue).HasColumnName("willActivelyContinue");
            entity.Property(e => e.ZipCode)
                .HasMaxLength(225)
                .IsUnicode(false)
                .HasColumnName("zipCode");
            entity.Property(e => e.ZipCode2)
                .HasMaxLength(225)
                .IsUnicode(false)
                .HasColumnName("zipCode2");
            entity.Property(e => e.ZoomOptionId).HasColumnName("zoomOptionId");

            entity.HasOne(d => d.BonusType).WithMany(p => p.TasMainEmployees)
                .HasForeignKey(d => d.BonusTypeId)
                .HasConstraintName("FK_Employee_Bonus_Type");

            entity.HasOne(d => d.Branch).WithMany(p => p.TasMainEmployees)
                .HasForeignKey(d => d.BranchId)
                .HasConstraintName("FK_Employee_Branch");

            entity.HasOne(d => d.CurrentCompany).WithMany(p => p.TasMainEmployees)
                .HasForeignKey(d => d.CurrentCompanyId)
                .HasConstraintName("FK_Employee_Current_Company");

            entity.HasOne(d => d.Department).WithMany(p => p.TasMainEmployees)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("FK_Employee_Department");

            entity.HasOne(d => d.EmployeeType).WithMany(p => p.TasMainEmployees)
                .HasForeignKey(d => d.EmployeeTypeId)
                .HasConstraintName("FK_Employee_Employee_Type");

            entity.HasOne(d => d.EmploymentStatus).WithMany(p => p.TasMainEmployees)
                .HasForeignKey(d => d.EmploymentStatusId)
                .HasConstraintName("FK_Employee_Employment_Status");

            entity.HasOne(d => d.Hierarchy).WithMany(p => p.TasMainEmployees)
                .HasForeignKey(d => d.HierarchyId)
                .HasConstraintName("FK_Employee_Hierarchy");

            entity.HasOne(d => d.JobTitle).WithMany(p => p.TasMainEmployees)
                .HasForeignKey(d => d.JobTitleId)
                .HasConstraintName("FK_Employee_Job_Title");

            entity.HasOne(d => d.Laptop).WithMany(p => p.TasMainEmployees)
                .HasForeignKey(d => d.LaptopId)
                .HasConstraintName("FK_Employee_Laptop");

            entity.HasOne(d => d.LeadSource).WithMany(p => p.TasMainEmployees)
                .HasForeignKey(d => d.LeadSourceId)
                .HasConstraintName("FK_Employee_Lead_Source");

            entity.HasOne(d => d.Manager).WithMany(p => p.TasMainEmployees)
                .HasForeignKey(d => d.ManagerId)
                .HasConstraintName("FK_Employee_Manager");

            entity.HasOne(d => d.Monitor).WithMany(p => p.TasMainEmployees)
                .HasForeignKey(d => d.MonitorId)
                .HasConstraintName("FK_Employee_Monitor");

            entity.HasOne(d => d.PaymentDate).WithMany(p => p.TasMainEmployees)
                .HasForeignKey(d => d.PaymentDateId)
                .HasConstraintName("FK_Employee_Payment_Date");

            entity.HasOne(d => d.RecoverableTimeFrame).WithMany(p => p.TasMainEmployees)
                .HasForeignKey(d => d.RecoverableTimeFrameId)
                .HasConstraintName("FK_Employee_Recoverable_Timeframe");

            entity.HasOne(d => d.ResidesIn).WithMany(p => p.TasMainEmployeeResidesIns)
                .HasForeignKey(d => d.ResidesInId)
                .HasConstraintName("FK_Employee_Resides_In");

            entity.HasOne(d => d.SalaryType).WithMany(p => p.TasMainEmployees)
                .HasForeignKey(d => d.SalaryTypeId)
                .HasConstraintName("FK_Employee_Salary_Type");

            entity.HasOne(d => d.ShippingAddress).WithMany(p => p.TasMainEmployees)
                .HasForeignKey(d => d.ShippingAddressId)
                .HasConstraintName("FK_Employee_Ship_Address");

            entity.HasOne(d => d.State).WithMany(p => p.TasMainEmployeeStates)
                .HasForeignKey(d => d.StateId)
                .HasConstraintName("FK_Employee_State");

            entity.HasOne(d => d.StateId2Navigation).WithMany(p => p.TasMainEmployeeStateId2Navigations)
                .HasForeignKey(d => d.StateId2)
                .HasConstraintName("FK_Employee_State_2");

            entity.HasOne(d => d.Status).WithMany(p => p.TasMainEmployees)
                .HasForeignKey(d => d.StatusId)
                .HasConstraintName("FK_Employee_Status");

            entity.HasOne(d => d.Type).WithMany(p => p.TasMainEmployees)
                .HasForeignKey(d => d.TypeId)
                .HasConstraintName("FK_Employee_Type");

            entity.HasOne(d => d.ZoomOption).WithMany(p => p.TasMainEmployees)
                .HasForeignKey(d => d.ZoomOptionId)
                .HasConstraintName("FK_Employee_Zoom_Options");
        });

        modelBuilder.Entity<TasMainField>(entity =>
        {
            entity.HasKey(e => e.FieldId).HasName("PK_tas_fields");

            entity.ToTable("tas_main_fields");

            entity.Property(e => e.FieldId).HasColumnName("fieldId");
            entity.Property(e => e.DataType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("dataType");
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.FieldIdentifier)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("fieldIdentifier");
            entity.Property(e => e.FieldName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("fieldName");
            entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");
            entity.Property(e => e.MilestoneId).HasColumnName("milestoneId");
            entity.Property(e => e.MilestoneIdBranch).HasColumnName("milestoneIdBranch");
            entity.Property(e => e.TabId).HasColumnName("tabId");
        });

        modelBuilder.Entity<TasMainLeadCompensation>(entity =>
        {
            entity.HasKey(e => e.CompensationId).HasName("PK__tas_main__C5E68CBDCEEAC7AB");

            entity.ToTable("tas_main_lead_compensation");

            entity.Property(e => e.CompensationId).HasColumnName("compensationId");
            entity.Property(e => e.Amount)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("amount");
            entity.Property(e => e.CompensationTypeId).HasColumnName("compensationTypeId");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.CreatedBy).HasColumnName("createdBy");
            entity.Property(e => e.EmployeeId).HasColumnName("employeeId");
            entity.Property(e => e.InclusiveOfOthers).HasColumnName("inclusiveOfOthers");
            entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");
            entity.Property(e => e.PayType)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("payType");
            entity.Property(e => e.RetroactiveStructure).HasColumnName("retroactiveStructure");
            entity.Property(e => e.StructureType)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("structureType");
            entity.Property(e => e.TierCriteria)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("tierCriteria");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updatedAt");
            entity.Property(e => e.UpdatedBy).HasColumnName("updatedBy");

            entity.HasOne(d => d.RetroactiveStructureNavigation).WithMany(p => p.TasMainLeadCompensations)
                .HasForeignKey(d => d.RetroactiveStructure)
                .HasConstraintName("FK_LeadCompensation_RetroactiveStructure");
        });

        modelBuilder.Entity<TasMainNote>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tas_rs_n__03C97EFDE8651D05");

            entity.ToTable("tas_main_notes");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CommunicationDate)
                .HasColumnType("datetime")
                .HasColumnName("communicationDate");
            entity.Property(e => e.CommunicationEndTime)
                .HasColumnType("datetime")
                .HasColumnName("communicationEndTime");
            entity.Property(e => e.CommunicationMethodId).HasColumnName("communicationMethodId");
            entity.Property(e => e.CommunicationStartTime)
                .HasColumnType("datetime")
                .HasColumnName("communicationStartTime");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.CreatedBy).HasColumnName("createdBy");
            entity.Property(e => e.Description)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.EmployeeId).HasColumnName("employeeId");
            entity.Property(e => e.FollowupDate)
                .HasColumnType("datetime")
                .HasColumnName("followupDate");
            entity.Property(e => e.FollowupEndTime)
                .HasColumnType("datetime")
                .HasColumnName("followupEndTime");
            entity.Property(e => e.FollowupMethodId).HasColumnName("followupMethodId");
            entity.Property(e => e.FollowupStartTime)
                .HasColumnType("datetime")
                .HasColumnName("followupStartTime");
            entity.Property(e => e.IsAnytime).HasColumnName("isAnytime");
            entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");
            entity.Property(e => e.Notified).HasColumnName("notified");
            entity.Property(e => e.Title)
                .HasMaxLength(225)
                .IsUnicode(false)
                .HasColumnName("title");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updatedAt");
            entity.Property(e => e.UpdatedBy).HasColumnName("updatedBy");
        });

        modelBuilder.Entity<TasMainUser>(entity =>
        {
            entity.HasKey(e => e.UserId)
                .HasName("PK_EMS_User")
                .HasFillFactor(90);

            entity.ToTable("tas_main_user");

            entity.HasIndex(e => new { e.UserId, e.ModuleId, e.RoleId, e.TransId }, "NonClusteredIndex-20180411-153101");

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.AllowedRecordIds)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.AllowedRecords)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.BranchId).HasColumnName("BranchID");
            entity.Property(e => e.Code)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.EntityId).HasColumnName("EntityID");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FullName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Job)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("JOB");
            entity.Property(e => e.JobTitleId).HasColumnName("JobTitleID");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ModuleId).HasColumnName("ModuleID");
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.TransId).HasColumnName("TransID");
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UserPassword)
                .HasMaxLength(500)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TasObEmployee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tas_ob_e__3214EC07B9ECD77D");

            entity.ToTable("tas_ob_employee");

            entity.Property(e => e.Id).HasMaxLength(50);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Department).HasMaxLength(100);
            entity.Property(e => e.EmployeeType).HasMaxLength(50);
            entity.Property(e => e.Manager).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Position).HasMaxLength(100);
            entity.Property(e => e.Progress).HasMaxLength(10);
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<TasObOnboardingTask>(entity =>
        {
            entity.HasKey(e => e.TaskId).HasName("PK__tas_ob_o__7C6949B1A14BD9BF");

            entity.ToTable("tas_ob_onboardingTasks");

            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.EmployeeId).HasMaxLength(50);
            entity.Property(e => e.LastModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.TaskName).HasMaxLength(255);

            entity.HasOne(d => d.Category).WithMany(p => p.TasObOnboardingTasks)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Task_Category");

            entity.HasOne(d => d.Employee).WithMany(p => p.TasObOnboardingTasks)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Task_Employee");
        });

        modelBuilder.Entity<TasObOnboardingTaskCategory>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__tas_ob_o__19093A0BC9109B68");

            entity.ToTable("tas_ob_onboardingTaskCategories");

            entity.HasIndex(e => new { e.CategoryName, e.EmployeeId }, "UQ_Category_Employee").IsUnique();

            entity.Property(e => e.CategoryName).HasMaxLength(100);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.EmployeeId).HasMaxLength(50);
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Employee).WithMany(p => p.TasObOnboardingTaskCategories)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Category_Employee");
        });

        modelBuilder.Entity<TasSetupBonusType>(entity =>
        {
            entity.HasKey(e => e.BonusTypeId).HasName("PK__tas_setu__A9721657A175F0B1");

            entity.ToTable("tas_setup_bonus_type");

            entity.Property(e => e.BonusTypeId).HasColumnName("bonusTypeId");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.CreatedBy).HasColumnName("createdBy");
            entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");
            entity.Property(e => e.Name)
                .HasMaxLength(225)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updatedAt");
            entity.Property(e => e.UpdatedBy).HasColumnName("updatedBy");
        });

        modelBuilder.Entity<TasSetupBranch>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_TAS_Setup_Branch");

            entity.ToTable("tas_setup_branch");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Address)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.BranchCode)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.BranchManagerId).HasColumnName("BranchManagerID");
            entity.Property(e => e.BranchName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.City)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.EntityId).HasColumnName("EntityID");
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("IPAddress");
            entity.Property(e => e.Macaddress)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MACAddress");
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.State)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.TerminationDate).HasColumnType("datetime");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            entity.Property(e => e.ZipCode)
                .HasMaxLength(25)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TasSetupChannel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_TAS_Setup_Channel");

            entity.ToTable("tas_setup_channel");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("IPAddress");
            entity.Property(e => e.Macaddress)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MACAddress");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<TasSetupCommunicationMethod>(entity =>
        {
            entity.HasKey(e => e.CommunicationMethodId).HasName("PK__tas_rs_c__6A2BD5A371D34424");

            entity.ToTable("tas_setup_communication_method");

            entity.Property(e => e.CommunicationMethodId).HasColumnName("communicationMethodId");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.CreatedBy).HasColumnName("createdBy");
            entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");
            entity.Property(e => e.Name)
                .HasMaxLength(225)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updatedAt");
            entity.Property(e => e.UpdatedBy).HasColumnName("updatedBy");
        });

        modelBuilder.Entity<TasSetupCompensationType>(entity =>
        {
            entity.HasKey(e => e.CompensationTypeId).HasName("PK__tas_setu__2E01012B786E7E3F");

            entity.ToTable("tas_setup_compensation_type");

            entity.Property(e => e.CompensationTypeId).HasColumnName("compensationTypeId");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.CreatedBy).HasColumnName("createdBy");
            entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");
            entity.Property(e => e.Name)
                .HasMaxLength(225)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updatedAt");
            entity.Property(e => e.UpdatedBy).HasColumnName("updatedBy");
        });

        modelBuilder.Entity<TasSetupCurrentcompany>(entity =>
        {
            entity.HasKey(e => e.CurrentCompanyId).HasName("PK__TAS_RS_C__3214EC27FBA26115");

            entity.ToTable("tas_setup_currentcompany");

            entity.Property(e => e.CurrentCompanyId).HasColumnName("currentCompanyId");
            entity.Property(e => e.Code)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("code");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.CreatedBy).HasColumnName("createdBy");
            entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updatedAt");
            entity.Property(e => e.UpdatedBy).HasColumnName("updatedBy");
        });

        modelBuilder.Entity<TasSetupDepartment>(entity =>
        {
            entity.HasKey(e => e.DepartmentId).HasName("PK__tas_setu__F9B8346DE26EF394");

            entity.ToTable("tas_setup_department");

            entity.Property(e => e.DepartmentId).HasColumnName("departmentId");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.CreatedBy).HasColumnName("createdBy");
            entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");
            entity.Property(e => e.Name)
                .HasMaxLength(225)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updatedAt");
            entity.Property(e => e.UpdatedBy).HasColumnName("updatedBy");
        });

        modelBuilder.Entity<TasSetupEmployeeType>(entity =>
        {
            entity.HasKey(e => e.EmployeeTypeId).HasName("PK__tas_setu__28A843A40A52DAA7");

            entity.ToTable("tas_setup_employee_type");

            entity.Property(e => e.EmployeeTypeId).HasColumnName("employeeTypeId");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.CreatedBy).HasColumnName("createdBy");
            entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");
            entity.Property(e => e.Name)
                .HasMaxLength(225)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updatedAt");
            entity.Property(e => e.UpdatedBy).HasColumnName("updatedBy");
        });

        modelBuilder.Entity<TasSetupEmploymentStatus>(entity =>
        {
            entity.HasKey(e => e.EmploymentStatusId).HasName("PK__tas_setu__F51F0D62B8C28123");

            entity.ToTable("tas_setup_employment_status");

            entity.Property(e => e.EmploymentStatusId).HasColumnName("employmentStatusId");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.CreatedBy).HasColumnName("createdBy");
            entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");
            entity.Property(e => e.Name)
                .HasMaxLength(225)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updatedAt");
            entity.Property(e => e.UpdatedBy).HasColumnName("updatedBy");
        });

        modelBuilder.Entity<TasSetupEntity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_TAS_Setup_Entity");

            entity.ToTable("tas_setup_entity");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Address)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.ChannelId).HasColumnName("ChannelID");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.EntityName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.HiringManagerId).HasColumnName("HiringManagerID");
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("IPAddress");
            entity.Property(e => e.Macaddress)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MACAddress");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<TasSetupHierarchy>(entity =>
        {
            entity.HasKey(e => e.HierarchyId).HasName("PK__TAS_RS_H__3214EC27C83A8725");

            entity.ToTable("tas_setup_hierarchy");

            entity.Property(e => e.HierarchyId).HasColumnName("hierarchyId");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.CreatedBy).HasColumnName("createdBy");
            entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updatedAt");
            entity.Property(e => e.UpdatedBy).HasColumnName("updatedBy");
        });

        modelBuilder.Entity<TasSetupJobTitle>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_TAS_Setup_JobTitle");

            entity.ToTable("tas_setup_job_title");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("IPAddress");
            entity.Property(e => e.Macaddress)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MACAddress");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<TasSetupLaptop>(entity =>
        {
            entity.HasKey(e => e.LaptopId).HasName("PK__tas_setu__5256130E4AFF70C4");

            entity.ToTable("tas_setup_laptop");

            entity.Property(e => e.LaptopId).HasColumnName("laptopId");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.CreatedBy).HasColumnName("createdBy");
            entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");
            entity.Property(e => e.Name)
                .HasMaxLength(225)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updatedAt");
            entity.Property(e => e.UpdatedBy).HasColumnName("updatedBy");
        });

        modelBuilder.Entity<TasSetupManager>(entity =>
        {
            entity.HasKey(e => e.ManagerId).HasName("PK__tas_setu__47E0141F01DC8C80");

            entity.ToTable("tas_setup_manager");

            entity.Property(e => e.ManagerId).HasColumnName("managerId");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.CreatedBy).HasColumnName("createdBy");
            entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");
            entity.Property(e => e.Name)
                .HasMaxLength(225)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updatedAt");
            entity.Property(e => e.UpdatedBy).HasColumnName("updatedBy");
        });

        modelBuilder.Entity<TasSetupMilestone>(entity =>
        {
            entity.HasKey(e => e.MilestoneId).HasName("PK_tas_milestones");

            entity.ToTable("tas_setup_milestones");

            entity.Property(e => e.MilestoneId).HasColumnName("milestoneId");
            entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");
            entity.Property(e => e.MilestoneName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("milestoneName");
        });

        modelBuilder.Entity<TasSetupMonitor>(entity =>
        {
            entity.HasKey(e => e.MonitorId).HasName("PK__tas_setu__74B3113D35889E98");

            entity.ToTable("tas_setup_monitor");

            entity.Property(e => e.MonitorId).HasColumnName("monitorId");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.CreatedBy).HasColumnName("createdBy");
            entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");
            entity.Property(e => e.Name)
                .HasMaxLength(225)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updatedAt");
            entity.Property(e => e.UpdatedBy).HasColumnName("updatedBy");
        });

        modelBuilder.Entity<TasSetupPaymentDate>(entity =>
        {
            entity.HasKey(e => e.PaymentDateId).HasName("PK__tas_setu__ED4C97F7B8939F01");

            entity.ToTable("tas_setup_payment_date");

            entity.Property(e => e.PaymentDateId).HasColumnName("paymentDateId");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.CreatedBy).HasColumnName("createdBy");
            entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");
            entity.Property(e => e.Name)
                .HasMaxLength(225)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updatedAt");
            entity.Property(e => e.UpdatedBy).HasColumnName("updatedBy");
        });

        modelBuilder.Entity<TasSetupRecoverableTimeFrame>(entity =>
        {
            entity.HasKey(e => e.RecoverableTimeFrameId).HasName("PK__tas_setu__928A6D038EB66D14");

            entity.ToTable("tas_setup_recoverable_time_frame");

            entity.Property(e => e.RecoverableTimeFrameId).HasColumnName("recoverableTimeFrameId");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.CreatedBy).HasColumnName("createdBy");
            entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");
            entity.Property(e => e.Name)
                .HasMaxLength(225)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updatedAt");
            entity.Property(e => e.UpdatedBy).HasColumnName("updatedBy");
        });

        modelBuilder.Entity<TasSetupRetroactiveStructure>(entity =>
        {
            entity.HasKey(e => e.RetroactiveStructureId).HasName("PK__tas_setu__E779A3F111538071");

            entity.ToTable("tas_setup_retroactive_structure");

            entity.Property(e => e.RetroactiveStructureId).HasColumnName("retroactiveStructureId");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.CreatedBy).HasColumnName("createdBy");
            entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");
            entity.Property(e => e.Name)
                .HasMaxLength(225)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updatedAt");
            entity.Property(e => e.UpdatedBy).HasColumnName("updatedBy");
        });

        modelBuilder.Entity<TasSetupSalaryType>(entity =>
        {
            entity.HasKey(e => e.SalaryTypeId).HasName("PK__tas_setu__65784912F18DA772");

            entity.ToTable("tas_setup_salary_type");

            entity.Property(e => e.SalaryTypeId).HasColumnName("salaryTypeId");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.CreatedBy).HasColumnName("createdBy");
            entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");
            entity.Property(e => e.Name)
                .HasMaxLength(225)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updatedAt");
            entity.Property(e => e.UpdatedBy).HasColumnName("updatedBy");
        });

        modelBuilder.Entity<TasSetupShippingAddress>(entity =>
        {
            entity.HasKey(e => e.ShippingAddressId).HasName("PK__tas_setu__26E2B4ABE3945F44");

            entity.ToTable("tas_setup_shipping_address");

            entity.Property(e => e.ShippingAddressId).HasColumnName("shippingAddressId");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.CreatedBy).HasColumnName("createdBy");
            entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");
            entity.Property(e => e.Name)
                .HasMaxLength(225)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updatedAt");
            entity.Property(e => e.UpdatedBy).HasColumnName("updatedBy");
        });

        modelBuilder.Entity<TasSetupState>(entity =>
        {
            entity.HasKey(e => e.Id)
                .HasName("PK_EMS_Setup_State")
                .HasFillFactor(90);

            entity.ToTable("tas_setup_state");

            entity.HasIndex(e => e.Id, "NonClusteredIndex-20180411-153005");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.CreatedBy).HasColumnName("createdBy");
            entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");
            entity.Property(e => e.StateFullName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.StateName).HasMaxLength(50);
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updatedAt");
            entity.Property(e => e.UpdatedBy).HasColumnName("updatedBy");
        });

        modelBuilder.Entity<TasSetupStatus>(entity =>
        {
            entity.HasKey(e => e.StatusId).HasName("PK__tas_rs_s__36257A1802E33CF3");

            entity.ToTable("tas_setup_status");

            entity.Property(e => e.StatusId).HasColumnName("statusId");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.CreatedBy).HasColumnName("createdBy");
            entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");
            entity.Property(e => e.Name)
                .HasMaxLength(225)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updatedAt");
            entity.Property(e => e.UpdatedBy).HasColumnName("updatedBy");
        });

        modelBuilder.Entity<TasSetupTemplateType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TAS_Setu__3214EC077534D16C");

            entity.ToTable("tas_setup_template_type");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("IPAddress");
            entity.Property(e => e.Macaddress)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("MACAddress");
            entity.Property(e => e.TemplateName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<TasSetupType>(entity =>
        {
            entity.HasKey(e => e.TypeId).HasName("PK__tas_rs_t__F04DF13AF2BA3DE9");

            entity.ToTable("tas_setup_type");

            entity.Property(e => e.TypeId).HasColumnName("typeId");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.CreatedBy).HasColumnName("createdBy");
            entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");
            entity.Property(e => e.Name)
                .HasMaxLength(225)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updatedAt");
            entity.Property(e => e.UpdatedBy).HasColumnName("updatedBy");
        });

        modelBuilder.Entity<TasSetupUserRole>(entity =>
        {
            entity.HasKey(e => e.Id)
                .HasName("PK__TAS_Setu__3214EC275BE2A6F2")
                .HasFillFactor(90);

            entity.ToTable("tas_setup_user_role");

            entity.HasIndex(e => e.Id, "NonClusteredIndex-20180411-153034");

            entity.Property(e => e.Id).HasColumnName("ID");
        });

        modelBuilder.Entity<TasSetupZoomOption>(entity =>
        {
            entity.HasKey(e => e.ZoomOptionId).HasName("PK__tas_setu__40602AFA7E413CF9");

            entity.ToTable("tas_setup_zoom_option");

            entity.Property(e => e.ZoomOptionId).HasColumnName("zoomOptionId");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.CreatedBy).HasColumnName("createdBy");
            entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");
            entity.Property(e => e.Name)
                .HasMaxLength(225)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updatedAt");
            entity.Property(e => e.UpdatedBy).HasColumnName("updatedBy");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
