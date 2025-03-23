using AngielskiNauka.ModelApi;
using AngielskiNauka.Unit;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AngielskiNauka.Pages
{
    public class FiszkaModel : PageModel
    {


        public List<Slowo> List;
        public int poziom;
        AngService _service;

        public FiszkaModel(AngService service)
        {
            _service = service;
        }

        public void OnGet(int id = 1)
        {
            poziom = id;

            List = _service.DaneFiszka(id).Select(
                (j, index) => new Slowo()
                {
                    Id = index + 1,
                    Pol = j.Pol,
                    Ang = j.Ang
                }).ToList();


        }
    }
}
