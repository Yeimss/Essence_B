using System;
using System.Collections.Generic;

namespace Essence_B.Models.DB;

public partial class Tbhouse
{
    public int IdHouse { get; set; }

    public string? House { get; set; }

    public short? IdOrigin { get; set; }

    public virtual Tborigin? IdOriginNavigation { get; set; }

    public virtual ICollection<Tbperfum> Tbperfums { get; set; } = new List<Tbperfum>();
}
