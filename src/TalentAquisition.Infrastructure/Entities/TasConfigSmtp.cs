using System;
using System.Collections.Generic;

namespace TalentAquisition.Infrastructure.Entities;

public partial class TasConfigSmtp
{
    public int Id { get; set; }

    public string? MailFrom { get; set; }

    public string? MailFromName { get; set; }

    public string? SmtpSetting { get; set; }

    public string? Password { get; set; }

    public string? Port { get; set; }

    public bool IsSsl { get; set; }
}
