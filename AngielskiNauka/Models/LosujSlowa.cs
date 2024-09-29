using System;
using System.Collections.Generic;

namespace AngielskiNauka.Models;

public partial class LosujSlowa
{
    public int LosujSlowaId { get; set; }

    public int LosujId { get; set; }

    public int SlowoId { get; set; }

    public virtual Losuj Losuj { get; set; } = null!;
}
