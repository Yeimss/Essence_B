using System;
using System.Collections.Generic;

namespace Essence_B.Models.DB;

public partial class TbRol
{
    public int IdRol { get; set; }

    public string? Rol { get; set; }

    public virtual ICollection<TbUser> TbUsers { get; set; } = new List<TbUser>();
}
