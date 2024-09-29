using System;
using System.Collections.Generic;

namespace AngielskiNauka.Models;

public partial class Dane
{
    public int DaneId { get; set; }

    public string Ang { get; set; } = null!;

    public string Pol { get; set; } = null!;

    public DateTime Data { get; set; }

    public int PoziomId { get; set; }

    public virtual Poziom Poziom { get; set; } = null!;
}
