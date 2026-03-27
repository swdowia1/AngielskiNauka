using AngielskiNauka.Unit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AngielskiNauka.Pages
{
    public class SlowkaModel : PageModel
    {
        AngService _service;
        public string PoziomName { get; set; }
        public int poziomid { get; set; }
        public SlowkaModel(AngService service)
        {
            _service = service;
        }

        public void OnGet(int id = 1)
        {
            var poziom = _service.GetPoziom(id);
            PoziomName = poziom.Nazwa;
            poziomid = id;
        }
    }
}
