using System;
using System.Collections.Generic;

namespace health_api._Shared.dbc.auth;

public partial class License
{
    public int Id { get; set; }

    public string? Hid { get; set; }

    public int? Type { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public string? AvailableAppointment { get; set; }

    public int? Rcb { get; set; }

    public int? Rub { get; set; }

    public DateTime? Rct { get; set; }

    public DateTime? Rut { get; set; }

    public bool? Ractive { get; set; }

    public bool? Rdeleted { get; set; }

    public virtual ICollection<UserLicense> UserLicenses { get; set; } = new List<UserLicense>();
}
