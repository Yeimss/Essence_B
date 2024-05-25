using System;
using System.Collections.Generic;

namespace Essence_B.Models.DB;

public partial class Tborigin
{
    public short IdOrigin { get; set; }

    public string? Origin { get; set; }

    public virtual ICollection<Tbhouse> Tbhouses { get; set; } = new List<Tbhouse>();

    public virtual ICollection<Tbperfum> Tbperfums { get; set; } = new List<Tbperfum>();
}
