using System;
using System.Collections.Generic;

namespace AngielskiNauka.Models;

public partial class Poziom
{
    public int PoziomId { get; set; }

    public string Nazwa { get; set; } = null!;

    public virtual ICollection<Dane> Danes { get; set; } = new List<Dane>();

    public virtual ICollection<Stat> Stats { get; set; } = new List<Stat>();
}
