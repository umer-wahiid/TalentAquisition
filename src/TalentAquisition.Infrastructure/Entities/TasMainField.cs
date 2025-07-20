using System;
using System.Collections.Generic;

namespace TalentAquisition.Infrastructure.Entities;

public partial class TasMainField
{
    public int FieldId { get; set; }

    public string? FieldName { get; set; }

    public string FieldIdentifier { get; set; } = null!;

    public int? MilestoneId { get; set; }

    public string? Description { get; set; }

    public string? DataType { get; set; }

    public bool IsDeleted { get; set; }
}
