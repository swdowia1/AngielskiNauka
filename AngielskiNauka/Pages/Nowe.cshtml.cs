using AngielskiNauka.ModelApi;
using AngielskiNauka.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AngielskiNauka.Pages
{
    public class NoweModel : PageModel
    {
        AaaswswContext _db;
        public List<vString> poziomy;
        [BindProperty]
        public List<Upload> PreviewData { get; set; } = new();
        public int Ile { get; set; }
        public NoweModel(AaaswswContext db)
        {
            _db = db;
            poziomy = _db.Pozioms.Select(k => new vString() { Id = k.PoziomId, Name = k.Nazwa }).ToList();
            Ile = _db.Ustawienias.FirstOrDefault().Ile;
        }
        [BindProperty]
        public int Number { get; set; }
        [BindProperty]
        public IFormFile Upload { get; set; }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostPreviewAsync()
        {
            PreviewData = new List<Upload>();

            using (var reader = new StreamReader(Upload.OpenReadStream()))
            {
                int lp = 1;
                while (!reader.EndOfStream)
                {
                    var line = await reader.ReadLineAsync();

                   
                    
                        PreviewData.Add(new Upload(line,lp));
                    lp++;
                    
                }
            }

            return Page();
        }
        public IActionResult OnPostSave()
        {
            int gg = Number;

            return RedirectToPage();
        }
       

    }
}
