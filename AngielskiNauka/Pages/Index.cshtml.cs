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

        public void OnGet(int? id)
        {
            if (id == null)
            {
                var cookieValue = Request.Cookies["id"];
                if (int.TryParse(cookieValue, out int parsedId))
                {
                    id = parsedId;
                }
                else
                {
                    id = 51; // fallback na domyœln¹ wartoœæ
                }
            }
            else 
            {
                Response.Cookies.Append("id", id.Value.ToString());
            }

            // Teraz masz pewnoœæ, ¿e id ma wartoœæ
            int finalId = id.Value;

            var Poz = _service.GetPoziom(finalId);

            poziom = finalId;
            poziomnazwa = Poz.Nazwa;
            ile = _service.Ile();
            mnoznik = 100 / ile;

        }
    }
}
