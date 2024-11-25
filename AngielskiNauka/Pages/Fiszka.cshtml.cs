using AngielskiNauka.ModelApi;
using AngielskiNauka.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AngielskiNauka.Pages
{
    public class FiszkaModel : PageModel
    {


        public List<Slowo> List;
        public int poziom;
        AaaswswContext _db;

        public FiszkaModel(AaaswswContext db)
        {
            _db = db;
        }

        public void OnGet(int id = 1)
        {
            poziom = id;
            List = _db.Danes.ToList().OrderBy(d => d.Data).Where(p => p.PoziomId == id).Select(
                (j, index) => new Slowo()
                {
                    Id = index + 1,
                    Pol = j.Pol,
                    Ang = j.Ang
                }).ToList();


        }
    }
}
