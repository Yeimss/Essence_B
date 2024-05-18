using System;
using System.Collections.Generic;

namespace Essence_B.Models.DB;

public partial class TbOrigin
{
    public short IdOrigin { get; set; }

    public string? Origin { get; set; }

    public virtual ICollection<TbHouse> TbHouses { get; set; } = new List<TbHouse>();
}
