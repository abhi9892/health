using System;
using System.Collections.Generic;

namespace health_api._Shared.dbc.auth;

public partial class Project
{
    public int Id { get; set; }

    public string? Hid { get; set; }

    public string? Abbrv { get; set; }

    public string? Name { get; set; }

    public string? DisplayTitle { get; set; }

    public string? LogoPath { get; set; }

    public string? BaseUrl { get; set; }

    public bool? IsStartupProject { get; set; }

    public string? Theme { get; set; }

    public string? Config { get; set; }

    public int? Rcb { get; set; }

    public int? Rub { get; set; }

    public DateTime? Rct { get; set; }

    public DateTime? Rut { get; set; }

    public bool? Ractive { get; set; }

    public bool? Rdeleted { get; set; }
}
