using AngielskiNauka.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AngielskiNauka.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public string poziom;
        AaaswswContext _db;


        public IndexModel(ILogger<IndexModel> logger, AaaswswContext db)
        {
            _logger = logger;
            _db = db;
        }

        public void OnGet(int id = 1)
        {

            poziom = "poziom" + id;
        }
    }
}
