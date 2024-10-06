using AngielskiNauka.ModelApi;
using AngielskiNauka.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AngielskiNauka.Pages
{
    public class PoziomModel : PageModel
    {
        public List<PoziomName> lista { get; set; }
        AaaswswContext _db;

        public PoziomModel(AaaswswContext db)
        {
            _db = db;
        }

        public void OnGet()
        {
            lista = _db.Pozioms.Select(j => new PoziomName()
            {
                id = j.PoziomId,
                nazwa = j.Nazwa,

            }).ToList();
        }
    }
}
