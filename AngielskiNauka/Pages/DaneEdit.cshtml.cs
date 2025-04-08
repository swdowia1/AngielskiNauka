using AngielskiNauka.Models;
using AngielskiNauka.Unit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AngielskiNauka.Pages
{
    public class DaneEditModel : PageModel
    {
        public Dane d;
        IRepository _repository;

        public DaneEditModel(IRepository repository)
        {
            _repository = repository;
        }

        public void OnGet(int id=0)
        {
            d = _repository.GetById<Dane>(id);
        }
    }
}
