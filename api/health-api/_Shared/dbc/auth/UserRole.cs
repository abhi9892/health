using System;
using System.Collections.Generic;

namespace health_api._Shared.dbc.auth;

public partial class UserRole
{
    public int Id { get; set; }

    public string? Hid { get; set; }

    public int? UserId { get; set; }

    public int? RoleId { get; set; }

    public int? Rcb { get; set; }

    public int? Rub { get; set; }

    public DateTime? Rct { get; set; }

    public DateTime? Rut { get; set; }

    public bool? Ractive { get; set; }

    public bool? Rdeleted { get; set; }

    public virtual Role? Role { get; set; }

    public virtual User? User { get; set; }
}
