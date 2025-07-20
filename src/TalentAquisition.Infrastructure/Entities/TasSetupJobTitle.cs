﻿using System;
using System.Collections.Generic;

namespace TalentAquisition.Infrastructure.Entities;

public partial class TasSetupJobTitle
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public string? Ipaddress { get; set; }

    public string? Macaddress { get; set; }
}
