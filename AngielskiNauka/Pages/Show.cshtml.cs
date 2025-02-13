using AngielskiNauka.ModelApi;
using AngielskiNauka.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AngielskiNauka.Pages
{
    public class ShowModel : PageModel
    {
        public List<Dane> slowa { get; set; }
        public List<StatPodsumowanie> grupa { get; set; }
        AaaswswContext _db;

        public ShowModel(AaaswswContext db)
        {
            _db = db;
        }
        public void OnGet(int id = 1)
        {
            slowa = _db.Danes.Where(j => j.PoziomId == id).OrderBy(k => k.Stan)
                .ThenBy(j => j.Data)
                .Select(n => new Dane()
                {
                    Ang = n.Ang,
                    Pol = n.Pol,
                    Data = n.Data,
                    Stan = n.Stan
                }).ToList();
            grupa = slowa.Where(w => w.Stan < 0).GroupBy(j => j.Stan)
                .Select(k => new StatPodsumowanie()
                {
                    Stan = k.Key,
                    Ilosc = k.Count()
                }).ToList();
        }
    }
}
