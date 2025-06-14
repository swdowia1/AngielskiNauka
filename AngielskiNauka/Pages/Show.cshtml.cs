using AngielskiNauka.ModelApi;
using AngielskiNauka.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AngielskiNauka.Pages
{
    public class ShowModel : PageModel
    {
        public List<Dane> slowa { get; set; }
        public int Ile { get; set; }
        public string PoziomName { get; set; }
        public int poziomid { get; set; }
        public List<Podsumowanie> listByData { get; set; }
        public List<Podsumowanie> listByStatus { get; set; }
        AaaswswContext _db;

        public ShowModel(AaaswswContext db)
        {
            _db = db;
        }
        public void OnGet(int id = 1)
        {
           
            Poziom poziom = _db.Pozioms.FirstOrDefault(j => j.PoziomId == id);
            poziomid = id;
            PoziomName=poziom?.Nazwa ?? "Nie znaleziono poziomu";
            Ile = _db.Ustawienias.FirstOrDefault().Ile;
            slowa = _db.Danes.Where(j => j.PoziomId == id).OrderBy(k => k.Stan)
                .ThenBy(j => j.Data)
                .Select(n => new Dane()
                {
                    DaneId=n.DaneId,
                    Ang = n.Ang,
                    Pol = n.Pol,
                    Data = n.Data,
                    Stan = n.Stan,
DataAkt = n.DataAkt,
                }).ToList();


            listByData = slowa
                .GroupBy(n => n.DataAkt.Date)
                .Select(g => new Podsumowanie()
                {
                    nazwa = g.Key.ToString("yyyyMMdd", new System.Globalization.CultureInfo("pl-PL")),
                    ilosc = g.Count()
                }).OrderByDescending(n => n.nazwa)
                .ToList();

            listByStatus = slowa
               .GroupBy(n => n.Stan)
               .Select(g => new Podsumowanie()
               {
                   nazwa = g.Key.ToString(),
                   ilosc = g.Count()
               }).OrderBy(n => n.nazwa)
               .ToList();





        }
    }
}
