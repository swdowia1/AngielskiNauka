using AngielskiNauka.ModelApi;
using AngielskiNauka.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Globalization;

namespace AngielskiNauka.Pages
{
    public class StatModel : PageModel
    {
        public List<StatView> stat;
        AaaswswContext _db;

        public StatModel(AaaswswContext db)
        {
            _db = db;
        }

        public void OnGet()
        {
            CultureInfo polish = new CultureInfo("pl-PL");
            stat = _db.Stats.Where(w => w.Data > DateTime.Now.AddDays(-30)).OrderByDescending(j => j.Data).Select(h =>

               new StatView()
               {
                   Data = h.Data.ToString("MMMM d (dddd)", polish) + " " + h.Data.ToString("HH:mm"),
                   Ilosc = h.Ilosc,
                   Powyzej = h.Ilosc > 80,
                   Poziom = h.Poziom.Nazwa
               }
           ).ToList();
        }
    }
}
