using System;
using System.Collections.Generic;

namespace Essence_B.Models.DB;

public partial class Tbnote
{
    public short IdNote { get; set; }

    public string? Note { get; set; }

    public virtual ICollection<TbperfumNote> TbperfumNotes { get; set; } = new List<TbperfumNote>();
}
