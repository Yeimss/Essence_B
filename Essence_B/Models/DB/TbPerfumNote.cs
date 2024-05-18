using System;
using System.Collections.Generic;

namespace Essence_B.Models.DB;

public partial class TbPerfumNote
{
    public int IdPerfum { get; set; }

    public short IdNote { get; set; }

    public short IdNoteType { get; set; }

    public decimal? Price { get; set; }

    public virtual TbNote IdNoteNavigation { get; set; } = null!;

    public virtual TbNoteType IdNoteTypeNavigation { get; set; } = null!;

    public virtual TbPerfum IdPerfumNavigation { get; set; } = null!;
}
