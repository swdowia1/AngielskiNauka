using System;
using System.Collections.Generic;

namespace AngielskiNauka.Models;

public partial class Losuj
{
    public int LosujId { get; set; }

    public string Mazwa { get; set; } = null!;

    public int Ilosc { get; set; }

    public virtual ICollection<LosujSlowa> LosujSlowas { get; set; } = new List<LosujSlowa>();
}
