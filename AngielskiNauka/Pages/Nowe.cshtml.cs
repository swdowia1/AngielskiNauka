using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AngielskiNauka.Pages
{
    public class NoweModel : PageModel
    {
        [BindProperty]
        public IFormFile Upload { get; set; }
        public void OnGet()
        {
        }

        public async Task OnPostAsync()
        {
            var file = Upload.FileName;

            List<string> line = new List<string>();
            using (var reader = new StreamReader(Upload.OpenReadStream()))
            {
                while (reader.Peek() >= 0)
                    line.Add(reader.ReadLine());
            }
        }

    }
}
