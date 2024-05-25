using System;
using System.Collections.Generic;

namespace Essence_B.Models.DB;

public partial class Tbuser
{
    public int IdUser { get; set; }

    public string FirstName { get; set; } = null!;

    public string Lastname { get; set; } = null!;

    public string HashPassword { get; set; } = null!;

    public string SaltPassword { get; set; } = null!;

    public string Email { get; set; } = null!;

    public int? IdRol { get; set; }

    public virtual Tbrol? IdRolNavigation { get; set; }

    public virtual ICollection<Tbsale> Tbsales { get; set; } = new List<Tbsale>();
}
