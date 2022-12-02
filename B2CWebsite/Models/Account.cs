﻿namespace B2CWebsite.Models;

public partial class Account
{
    public int AccountId { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public bool? Active { get; set; }

    public string? FullName { get; set; }

    public int? RoleId { get; set; }

    public virtual Role? Role { get; set; }
}
