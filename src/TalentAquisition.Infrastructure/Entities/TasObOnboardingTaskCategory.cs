using System;
using System.Collections.Generic;

namespace TalentAquisition.Infrastructure.Entities;

public partial class TasObOnboardingTaskCategory
{
    public int CategoryId { get; set; }

    public string CategoryName { get; set; } = null!;

    public string EmployeeId { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual TasObEmployee Employee { get; set; } = null!;

    public virtual ICollection<TasObOnboardingTask> TasObOnboardingTasks { get; set; } = new List<TasObOnboardingTask>();
}
