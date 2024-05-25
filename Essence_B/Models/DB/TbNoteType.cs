using System;
using System.Collections.Generic;

namespace Essence_B.Models.DB;

public partial class TbnoteType
{
    public short IdNoteType { get; set; }

    public string? NoteType { get; set; }

    public virtual ICollection<TbperfumNote> TbperfumNotes { get; set; } = new List<TbperfumNote>();
}
