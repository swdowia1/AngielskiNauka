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
        AaaswswContext _db;

        public StatModel(AaaswswContext db)
        {
            _db = db;
            pods = new List<Podsumowanie>();
        }

        public void OnGet()
        {
            //string[] plik = Directory.GetFiles(@"C:\dyskD\wywal\angHtml", "*.txt");


            //foreach (var item in plik)
            //{
            //    string[] linie = System.IO.File.ReadAllLines(item);
            //    foreach (string linia in linie)
            //    {

            //        string[] kol = linia.Split(';');
            //        if (kol.Length == 2)
            //        {
            //            Dane d = new Dane();
            //            d.Ang = kol[0];
            //            d.Pol = kol[1];
            //            d.PoziomId = 1;
            //            d.Data = DateTime.Now;
            //            _db.Danes.Add(d);
            //        }


            //    }
            //    _db.SaveChanges();
            //}

            CultureInfo polish = new CultureInfo("pl-PL");
            stat = _db.Stats.Where(w => w.Data > DateTime.Now.AddDays(-30)).OrderByDescending(j => j.Data).Select(h =>

               new StatView()
               {
                   Data = h.Data.ToString("MMMM d (dddd)", polish) + " " + h.Data.ToString("HH:mm"),
                   Ilosc = h.Ilosc,
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
