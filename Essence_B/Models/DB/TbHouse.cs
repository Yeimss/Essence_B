using System;
using System.Collections.Generic;

namespace Essence_B.Models.DB;

public partial class TbHouse
{
    public int IdHouse { get; set; }

    public string? House { get; set; }

    public short? IdOrigin { get; set; }

    public virtual TbOrigin? IdOriginNavigation { get; set; }

    public virtual ICollection<TbPerfum> TbPerfums { get; set; } = new List<TbPerfum>();
}
