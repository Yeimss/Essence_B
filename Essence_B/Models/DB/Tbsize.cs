using System;
using System.Collections.Generic;

namespace Essence_B.Models.DB;

public partial class Tbsize
{
    public short IdSize { get; set; }

    public int? Size { get; set; }

    public virtual ICollection<TbperfumSize> TbperfumSizes { get; set; } = new List<TbperfumSize>();
}
