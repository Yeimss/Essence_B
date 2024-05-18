using System;
using System.Collections.Generic;

namespace Essence_B.Models.DB;

public partial class TbPerfum
{
    public int IdPerfum { get; set; }

    public string Name { get; set; } = null!;

    public int Size { get; set; }

    public int? IdHouse { get; set; }

    public short? IdGender { get; set; }

    public bool? Status { get; set; }

    public string? Description { get; set; }

    public short? IdConcentration { get; set; }

    public virtual TbConcentration? IdConcentrationNavigation { get; set; }

    public virtual TbGender? IdGenderNavigation { get; set; }

    public virtual TbHouse? IdHouseNavigation { get; set; }

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();

    public virtual ICollection<TbPerfumNote> TbPerfumNotes { get; set; } = new List<TbPerfumNote>();
}
