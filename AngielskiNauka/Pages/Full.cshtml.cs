using AngielskiNauka.ModelApi;
using AngielskiNauka.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AngielskiNauka.Pages
{
    public class FullModel : PageModel
    {
        public int poziom;
        public string poziomnazwa;
        public List<PoziomName> listPoziomName { get; set; }
        AaaswswContext _db;

        public FullModel(AaaswswContext db)
        {
            _db = db;
        }

        public void OnGet(int id = 4)
        {
            poziom = id;
            var Poz = _db.Pozioms.FirstOrDefault(k => k.PoziomId == id);

            poziomnazwa = Poz.Nazwa;
        }
    }
}
