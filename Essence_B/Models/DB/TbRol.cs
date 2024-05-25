using System;
using System.Collections.Generic;

namespace Essence_B.Models.DB;

public partial class Tbrol
{
    public int IdRol { get; set; }

    public string? Rol { get; set; }

    public virtual ICollection<Tbuser> Tbusers { get; set; } = new List<Tbuser>();
}
