using System;
using System.Collections.Generic;

namespace Essence_B.Models.DB;

public partial class TbNote
{
    public short IdNote { get; set; }

    public string? Note { get; set; }

    public virtual ICollection<TbPerfumNote> TbPerfumNotes { get; set; } = new List<TbPerfumNote>();
}
