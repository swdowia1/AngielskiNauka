using AngielskiNauka.ModelApi;
using AngielskiNauka.Unit;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AngielskiNauka.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;


        public int poziom;
        public string poziomnazwa;

        public List<PoziomName> listPoziomName { get; set; }
        AngService _db;


        public IndexModel(ILogger<IndexModel> logger, AngService db)
        {
            _logger = logger;
            _db = db;

        }

        public void OnGet(int id = 4)
        {

            var Poz = _db.GetPoziom(id);

            poziom = id;
            poziomnazwa = Poz.Nazwa;
        }
    }
}
