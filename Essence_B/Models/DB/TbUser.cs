using System;
using System.Collections.Generic;

namespace Essence_B.Models.DB;

public partial class TbUser
{
    public int IdUser { get; set; }

    public string Firstname { get; set; } = null!;

    public string Lastname { get; set; } = null!;

    public string HashPassword { get; set; } = null!;

    public string SaltPassword { get; set; } = null!;

    public string Email { get; set; } = null!;

    public int? IdRol { get; set; }

    public virtual TbRol? IdRolNavigation { get; set; }

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
}
