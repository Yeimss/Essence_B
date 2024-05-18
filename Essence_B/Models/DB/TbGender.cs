using System;
using System.Collections.Generic;

namespace Essence_B.Models.DB;

public partial class TbGender
{
    public short IdGender { get; set; }

    public string? Gender { get; set; }

    public virtual ICollection<TbPerfum> TbPerfums { get; set; } = new List<TbPerfum>();
}
