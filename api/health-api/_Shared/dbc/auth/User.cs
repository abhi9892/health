using System;
using System.Collections.Generic;

namespace health_api._Shared.dbc.auth;

public partial class User
{
    public int Id { get; set; }

    public string? Hid { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? FullName { get; set; }

    public string? Email { get; set; }

    public string? Contact { get; set; }

    public string? Password { get; set; }

    public int? FailedCount { get; set; }

    public bool? IsLock { get; set; }

    public int? Rcb { get; set; }

    public int? Rub { get; set; }

    public DateTime? Rct { get; set; }

    public DateTime? Rut { get; set; }

    public bool? Ractive { get; set; }

    public bool? Rdeleted { get; set; }

    public bool? IsLockedOut { get; set; }

    public virtual ICollection<UserLicense> UserLicenses { get; set; } = new List<UserLicense>();

    public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
}
