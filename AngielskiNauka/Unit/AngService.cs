
using AngielskiNauka.Models;

namespace AngielskiNauka.Unit
{
    public class AngService
    {
        IRepository _repository;
        IFunVMS _funVMS;

        public AngService(IRepository repository, IFunVMS funVMS)
        {
            _repository = repository;
            _funVMS = funVMS;
        }

        public Poziom GetPoziom(int id)
        {

            return _repository.GetById<Poziom>(id);
        }
        public decimal Faktura(List<decimal> dane)
        {

            return dane.Sum(k => (Math.Floor(k * 100) / 100));
        }

        public int LogikaBiznesowa()

        {
            List<string> nadawca = _funVMS.GetDataCacheOrder();
            foreach (var item in nadawca)
            {
                if (!item.StartsWith("a"))
                    _funVMS.SendMail();
            }

            return 1;
        }

        public int AddPoziom(string naz)
        {
            var p = new Poziom() { Nazwa = naz };
            _repository.Add(p);
            return 1;
        }
    }
}
