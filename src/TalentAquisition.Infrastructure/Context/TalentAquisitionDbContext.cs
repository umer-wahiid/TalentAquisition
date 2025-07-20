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
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-LMV5DEC;Integrated Security=true; Initial Catalog=TalentAquisition; Encrypt=False");

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
