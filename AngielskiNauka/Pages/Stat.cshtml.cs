using AngielskiNauka.ModelApi;
using AngielskiNauka.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Globalization;

namespace AngielskiNauka.Pages
{
    public class StatModel : PageModel
    {
        public List<StatView> stat;
        public List<Podsumowanie> pods;
        public int poziomid { get; set; }
        AaaswswContext _db;

        public StatModel(AaaswswContext db)
        {
            _db = db;
            pods = new List<Podsumowanie>();
        }

        public void OnGet(int id = 0)
        {
            poziomid = id;

            CultureInfo polish = new CultureInfo("pl-PL");
            stat = _db.Stats.Where(w => (id == 0 || (id > 0 && w.PoziomId == id)) && w.Data > DateTime.Now.AddDays(-30)).OrderByDescending(j => j.Data).Select(h =>

               new StatView()
               {
                   Data = h.Data.ToString("MMMM d (dddd)", polish) + " " + h.Data.ToString("HH:mm"),
                   Ilosc = h.Ilosc,
                   OK = h.Ok,
                   Zle = h.Zle,
                   Razem = h.Ok + h.Zle,
                   Powyzej = h.Ilosc > 80,
                   Poziom = h.Poziom.Nazwa,
                   Id = h.Id
               }
           ).ToList();

            var powyzej = stat.Where(h => h.Powyzej).ToList();
            pods = (from p in powyzej
                    group p by p.Poziom into g
                    select new Podsumowanie { nazwa = g.Key, ilosc = g.Count() }).ToList();
        }
    }
}
