using System;
using System.Collections.Generic;

namespace Essence_B.Models.DB;

public partial class Tbperfum
{
    public int IdPerfum { get; set; }

    public string Name { get; set; } = null!;

    public int Size { get; set; }

    public int? IdHouse { get; set; }

    public short? IdGender { get; set; }

    public short? IdOrigin { get; set; }

    public bool? Status { get; set; }

    public string? Description { get; set; }

    public short? IdConcentration { get; set; }

    public virtual Tbconcentration? IdConcentrationNavigation { get; set; }

    public virtual Tbgender? IdGenderNavigation { get; set; }

    public virtual Tbhouse? IdHouseNavigation { get; set; }

    public virtual Tborigin? IdOriginNavigation { get; set; }

    public virtual ICollection<TbperfumNote> TbperfumNotes { get; set; } = new List<TbperfumNote>();

    public virtual ICollection<TbperfumSize> TbperfumSizes { get; set; } = new List<TbperfumSize>();

    public virtual ICollection<Tbsale> Tbsales { get; set; } = new List<Tbsale>();
}
