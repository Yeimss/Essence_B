using System;
using System.Collections.Generic;

namespace Essence_B.Models.DB;

public partial class TbConcentration
{
    public short IdConcentration { get; set; }

    public string? Concentration { get; set; }

    public virtual ICollection<TbPerfum> TbPerfums { get; set; } = new List<TbPerfum>();
}
