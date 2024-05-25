using System;
using System.Collections.Generic;

namespace Essence_B.Models.DB;

public partial class TbperfumSize
{
    public int IdPerfum { get; set; }

    public short IdSize { get; set; }

    public short? IdNoteType { get; set; }

    public decimal? Price { get; set; }

    public virtual Tbperfum IdPerfumNavigation { get; set; } = null!;

    public virtual Tbsize IdSizeNavigation { get; set; } = null!;
}
