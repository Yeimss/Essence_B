using System;
using System.Collections.Generic;

namespace Essence_B.Models.DB;

public partial class TbNoteType
{
    public short IdNoteType { get; set; }

    public string? NoteType { get; set; }

    public virtual ICollection<TbPerfumNote> TbPerfumNotes { get; set; } = new List<TbPerfumNote>();
}
