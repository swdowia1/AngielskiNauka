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
        public NoweModel(AaaswswContext db)
        {
            _db = db;
            poziomy = _db.Pozioms.Select(k => new vString() { Id = k.PoziomId, Name = k.Nazwa }).ToList();
        }
        [BindProperty]
        public int Number { get; set; }
        [BindProperty]
        public IFormFile Upload { get; set; }
        public void OnGet()
        {
        }

        public async Task OnPostAsync()
        {
            //dodajemy dla hannii
            var file = Upload.FileName;

            List<string> line = new List<string>();
            using (var reader = new StreamReader(Upload.OpenReadStream()))
            {
                while (reader.Peek() >= 0)
                    line.Add(reader.ReadLine());
            }

            foreach (var item in line)
            {
                string[] kol = item.Split(";");
                Dane d = new Dane();
                d.Ang = kol[0];
                d.Pol = kol[1];
                d.PoziomId = Number;//poziom hania
                d.Data = DateTime.Now.AddMonths(-7);
                _db.Danes.Add(d);
            }
            _db.SaveChanges();
        }

    }
}
