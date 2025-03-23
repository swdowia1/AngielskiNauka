using AngielskiNauka.ModelApi;
using AngielskiNauka.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AngielskiNauka.Pages
{
    public class PoziomModel : PageModel
    {
        public List<PoziomName> lista { get; set; }
        AaaswswContext _service;

        public PoziomModel(AaaswswContext service)
        {
            _service = service;
        }

        public void OnGet()
        {
            lista = _service.Pozioms.Select(j => new PoziomName()
            {
                id = j.PoziomId,
                nazwa = j.Nazwa,

            }).ToList();
        }
    }
}
