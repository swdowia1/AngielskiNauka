using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Zadania.Models;

namespace Zadania.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private AaaonninenContext db;

        public IndexModel(ILogger<IndexModel> logger, AaaonninenContext db)
        {
            _logger = logger;
            this.db = db;
        }

        public void OnGet()
        {
            var dd = db.Jobs.ToList();
        }
    }
}
