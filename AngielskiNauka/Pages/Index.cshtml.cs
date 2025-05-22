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


        AngService _service;
        ConfigGlobal _config;

        public IndexModel(AngService service, ConfigGlobal config)
        {
            _service = service;
            _config = config;
        }

        public void OnGet(int id = 47)
        {

            var Poz = _service.GetPoziom(id);

            poziom = id;
            poziomnazwa = Poz.Nazwa;
            ile = _service.Ile();
            mnoznik = 100 / ile;

        }
    }
}
