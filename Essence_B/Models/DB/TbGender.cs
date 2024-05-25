using System;
using System.Collections.Generic;

namespace Essence_B.Models.DB;

public partial class Tbgender
{
    public short IdGender { get; set; }

    public string? Gender { get; set; }

    public virtual ICollection<Tbperfum> Tbperfums { get; set; } = new List<Tbperfum>();
}
