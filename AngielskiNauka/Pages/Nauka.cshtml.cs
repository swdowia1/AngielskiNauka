using AngielskiNauka.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AngielskiNauka.Pages
{
    public class NaukaModel : PageModel
    {
        public List<Dane> powtarzanie { get; set; }
        AaaswswContext _db;

        public NaukaModel(AaaswswContext db)
        {
            _db = db;
        }

        public void OnGet(int id = 1)
        {
            Stat s = _db.Stats.FirstOrDefault(k => k.Id == id);
            var pow = s.Repeat.Split("||", StringSplitOptions.RemoveEmptyEntries).ToList();
            powtarzanie = new List<Dane>();
            foreach (var item in pow)
            {
                string[] kol = item.Split(':');
                Dane d = new Dane() {DaneId=int.Parse(kol[0]), Ang = kol[1], Pol = kol[2] };
                powtarzanie.Add(d);
            }
        }
    }
}
