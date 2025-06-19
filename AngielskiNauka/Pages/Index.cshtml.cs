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
                    var cookieOptions = new CookieOptions
                    {
                        Expires = DateTimeOffset.UtcNow.AddDays(7), // cookie wa¿ne przez 7 dni
                        HttpOnly = true,
                        Secure = true,
                        IsEssential = true,
                        SameSite = SameSiteMode.Strict
                    };
                    Response.Cookies.Append("id", id.Value.ToString(), cookieOptions);
                }
            }
            else 
            {
                var cookieOptions = new CookieOptions
                {
                    Expires = DateTimeOffset.UtcNow.AddDays(7), // cookie wa¿ne przez 7 dni
                    HttpOnly = true,
                    Secure = true,
                    IsEssential = true,
                    SameSite = SameSiteMode.Strict
                };
                Response.Cookies.Append("id", id.Value.ToString(), cookieOptions);
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
