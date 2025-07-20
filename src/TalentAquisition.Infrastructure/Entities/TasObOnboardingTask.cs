using System;
using System.Collections.Generic;

namespace TalentAquisition.Infrastructure.Entities;

public partial class TasObOnboardingTask
{
    public int TaskId { get; set; }

    public string TaskName { get; set; } = null!;

    public bool IsCompleted { get; set; }

    public int CategoryId { get; set; }

    public string EmployeeId { get; set; } = null!;

    public DateTime? CreatedDate { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    public virtual TasObOnboardingTaskCategory Category { get; set; } = null!;

    public virtual TasObEmployee Employee { get; set; } = null!;
}
