using AngielskiNauka.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AngielskiNauka.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        AaaswswContext _db;
       

        public IndexModel(ILogger<IndexModel> logger, AaaswswContext db)
        {
            _logger = logger;
            _db = db;
        }

        public void OnGet()
        {
           
        }
    }
}
