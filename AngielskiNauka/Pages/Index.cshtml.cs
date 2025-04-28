using AngielskiNauka.Models;
using AngielskiNauka.Unit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AngielskiNauka.Pages
{
    public class IndexModel : PageModel
    {
        public int poziom;
        public int mnoznik;

        public string poziomnazwa;
        public int ile;


        AngService _db;
        ConfigGlobal _config;

        public IndexModel(AngService db, ConfigGlobal config)
        {
            _db = db;
            _config = config;
        }

        public void OnGet(int id = 4)
        {

            var Poz = _db.GetPoziom(id);

            poziom = id;
            poziomnazwa = Poz.Nazwa;
            ile = _config.Ile();
            mnoznik = 100 / ile;

        }
    }
}
