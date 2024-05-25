using System;
using System.Collections.Generic;

namespace Essence_B.Models.DB;

public partial class Tbconcentration
{
    public short IdConcentration { get; set; }

    public string? Concentration { get; set; }

    public virtual ICollection<Tbperfum> Tbperfums { get; set; } = new List<Tbperfum>();
}
