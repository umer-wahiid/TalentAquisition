﻿using System;
using System.Collections.Generic;

namespace TalentAquisition.Infrastructure.Entities;

public partial class TasSetupCompensationType
{
    public int CompensationTypeId { get; set; }

    public string? Name { get; set; }

    public bool? IsDeleted { get; set; }

    public int? CreatedBy { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
