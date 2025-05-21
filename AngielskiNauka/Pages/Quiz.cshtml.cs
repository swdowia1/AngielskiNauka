using AngielskiNauka.ModelApi;
using AngielskiNauka.Unit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AngielskiNauka.Pages
{
    public class QuizModel : PageModel
    {
        AngService _service;
        ConfigGlobal _config;

        public QuizModel(AngService db, ConfigGlobal config)
        {
            _service = db;
            _config = config;
        }

        public int poziom { get; set; }
      public  List<WordPair> wordPairs { get; set; }
        public void OnGet(int id = 1)
        {
            int ilosc = _service.Ile();

            poziom = id;

            var listastart = _service.DaneNauka(poziom, 14);

            wordPairs = listastart.Select(j => new WordPair()
            {
                En = j.Ang,
                Pl = j.Pol
            }).ToList();

        }
    }
}
