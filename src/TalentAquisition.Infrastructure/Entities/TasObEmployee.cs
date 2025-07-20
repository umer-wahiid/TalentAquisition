using System;
using System.Collections.Generic;

namespace TalentAquisition.Infrastructure.Entities;

public partial class TasObEmployee
{
    public string Id { get; set; } = null!;

    public string Name { get; set; } = null!;

    public DateOnly DateOfJoining { get; set; }

    public string Position { get; set; } = null!;

    public string Department { get; set; } = null!;

    public string EmployeeType { get; set; } = null!;

    public string? Manager { get; set; }

    public string Status { get; set; } = null!;

    public string Progress { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<TasObOnboardingTaskCategory> TasObOnboardingTaskCategories { get; set; } = new List<TasObOnboardingTaskCategory>();

    public virtual ICollection<TasObOnboardingTask> TasObOnboardingTasks { get; set; } = new List<TasObOnboardingTask>();
}
