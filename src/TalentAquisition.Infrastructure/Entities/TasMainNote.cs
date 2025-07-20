using System;
using System.Collections.Generic;

namespace TalentAquisition.Infrastructure.Entities;

public partial class TasMainNote
{
    public int Id { get; set; }

    public int EmployeeId { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int? CommunicationMethodId { get; set; }

    public int? FollowupMethodId { get; set; }

    public DateTime? FollowupDate { get; set; }

    public DateTime? FollowupStartTime { get; set; }

    public DateTime? FollowupEndTime { get; set; }

    public bool IsAnytime { get; set; }

    public bool IsDeleted { get; set; }

    public int CreatedBy { get; set; }

    public int UpdatedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public DateTime? CommunicationDate { get; set; }

    public DateTime? CommunicationStartTime { get; set; }

    public DateTime? CommunicationEndTime { get; set; }

    public bool Notified { get; set; }
}
