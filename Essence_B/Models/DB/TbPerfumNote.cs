using System;
using System.Collections.Generic;

namespace Essence_B.Models.DB;

public partial class TbperfumNote
{
    public int IdPerfum { get; set; }

    public short IdNote { get; set; }

    public short IdNoteType { get; set; }

    public decimal? Price { get; set; }

    public virtual Tbnote IdNoteNavigation { get; set; } = null!;

    public virtual TbnoteType IdNoteTypeNavigation { get; set; } = null!;

    public virtual Tbperfum IdPerfumNavigation { get; set; } = null!;
}
