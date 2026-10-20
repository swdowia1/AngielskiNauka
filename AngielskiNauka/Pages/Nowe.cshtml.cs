using AngielskiNauka.ModelApi;
using AngielskiNauka.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;


namespace AngielskiNauka.Pages
{
    public class NoweModel : PageModel
    {
        private const string SessionKey = "Slowka";
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
        private void OdczytajPodgladZSession()
        {
            var json = HttpContext.Session.GetString(SessionKey);

            PreviewData = string.IsNullOrEmpty(json)
                ? new List<Upload>()
                : JsonSerializer.Deserialize<List<Upload>>(json) ?? new List<Upload>();
        }
        private void ZapiszSlowkaDoSession()
        {
            var slowka = PreviewData
                .Where(x =>
                    string.IsNullOrWhiteSpace(x.Uwaga) &&
                    !string.IsNullOrWhiteSpace(x.ANG) &&
                    !string.IsNullOrWhiteSpace(x.POL))
                .Select(x => x)
                .ToList();

            HttpContext.Session.SetString(
                SessionKey,
                JsonSerializer.Serialize(slowka));
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
            PreviewData=PreviewData.OrderByDescending(k => k.Uwaga).ToList();
            return Page();
        }
        public IActionResult OnPostSave()
        {
            int gg = Number;

            return RedirectToPage();
        }
       

    }
}
