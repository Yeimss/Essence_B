using System;
using System.Collections.Generic;

namespace Essence_B.Models.DB;

public partial class Tbsale
{
    public int IdSale { get; set; }

    public int? Quantity { get; set; }

    public decimal? Price { get; set; }

    public DateTime? Date { get; set; }

    public DateOnly? SendDate { get; set; }

    public int? IdPerfum { get; set; }

    public int? IdUser { get; set; }

    public virtual Tbperfum? IdPerfumNavigation { get; set; }

    public virtual Tbuser? IdUserNavigation { get; set; }
}
