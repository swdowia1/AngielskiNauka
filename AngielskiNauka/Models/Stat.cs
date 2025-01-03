namespace AngielskiNauka.Models;

public partial class Stat
{
    public int Id { get; set; }

    public int Ilosc { get; set; }

    public DateTime Data { get; set; }

    public int PoziomId { get; set; }

    public virtual Poziom Poziom { get; set; } = null!;
    //do powtórek
    public string Repeat { get; set; }
}
