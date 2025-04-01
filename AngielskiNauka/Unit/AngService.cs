
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

        public async Task<int> AddStat(string ok, string zle, int poziom)
        {
            var parameters = new Dictionary<string, object>
{
    { "@oklist", ok },  // Zakładając, że oklist to ciąg wartości
    { "@zlelist",zle } ,
                {"@poziomid",poziom }
};
            await _repository.RunStoredProcedureNonQuery("[dbo].[AddStat]", parameters);

            return 1;
        }

        public Poziom GetPoziom(int id)
        {

            return _repository.GetById<Poziom>(id);
        }
        public decimal Faktura(List<decimal> dane)
        {

            return dane.Sum(k => (Math.Floor(k * 100) / 100));
        }

        public List<Dane> DaneFiszka(int id)
        {
            return _repository.GetAll<Dane>(k => k.PoziomId == id).OrderBy(k=>k.Stan).ToList();
        }

        public List<JobView> Zadania()
        {
            var lista=_repository.GetAllIncluding<Job>(j=> j.TaskTimes).ToList();

            List<JobView> jobs = lista.Select(k => new JobView()
            {
                Id = k.Id,
                Name = k.Text,
                JobTime = k.TaskTimes.Select(j => new JobTimeView(j.StartTime, j.EndTime)).ToList()

            }).ToList();

            foreach (var item in jobs)
            {
                item.TimeJob = classFun.TimeJobString(item.JobTime.Sum(k => k.Minute));
                item.TotalMInute = item.JobTime.Sum(k => k.Minute);
                item.Work = item.JobTime.Any(k => !k.End.HasValue)==true?1:0;
            }
            return jobs;
        }

        public List<Dane> DaneNauka(int id, int ilosc = 20)
        {
            return _repository.GetAll<Dane>(
       w => w.PoziomId == id,
       orderBy: w => w.Stan,
       descending: false,
       take: ilosc).ToList();
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

        public AddResult AddPoziom(string naz)
        {
            var p = new Poziom() { Nazwa = naz };
            var idNew = _repository.Add(p);
            return idNew;
        }
        public AddResult AddSlowo(string slowo)
        {
            var p = new Dane() { Ang = slowo, Pol = "", PoziomId = 27 };
            var idNew = _repository.Add(p);

            return idNew;
        }

        public string StatusOrder(int isonninenpl, int? max_realization, int? stsQue, int statussap, bool isZDS)
        {


            /*
 order-status-transport	  Status realizacji zamówienia
order-status-transport0	  Akceptacja zamówienia do realizacji
order-status-transport1	  Przyjęte do realizacji
order-status-transport2	  Zamówienie odrzucono
order-status-transport3	  Zamówienie wysłane
order-status-transport4	  Zamówienie wysłano
order-status-transport98  Dostępność do potwierdzenia
order-status-transport99  Czekam na wystawienie w kolejce

             */
            //todo swsw status zamowienia
            string result = "";
            if (statussap == 99)
                return "";
            if (isonninenpl == 1)
            {
                if (stsQue.HasValue)
                {
                    if (stsQue.Value == 0)
                        return _funVMS.KeyTransalate("order-status-transport99");// "Czekam na wysłanie";
                    if (stsQue.Value == 1)
                        return _funVMS.KeyTransalate("order-status-transport98");// "w trakcie przetwarzania";

                    //jesli jest z onninepl i jest w kolejce to zobacz status odpowiedzi
                    if (max_realization.HasValue)
                        return _funVMS.KeyTransalate("order-status-transport" + max_realization.Value.ToString());
                    else
                    {
                        if (stsQue == 3)
                            return _funVMS.KeyTransalate("order-status-transport97");
                        else
                            return "";
                    }

                }
                else
                    return "";
                //{
                //    if (isZDS)//order-status-transport99	Czekam na wystawienie w kolejce
                //        return KeyTransalate("order-status-transport99");// "Czekam na wystawienie w kolejce";
                //    else
                //        return KeyTransalate("order-status-transport98");//nie jestZDS  Dostępność do potwierdzenia
                //}
            }
            else
            {
                if (max_realization.HasValue)
                    return _funVMS.KeyTransalate("order-status-transport" + max_realization.Value.ToString());
                else
                    return "";
            }

            return "";
        }

        public int AddTask(string val)
        {
            Job j = new Job() { Text = val };
            var r=_repository.Add(j);
            return r.KeyInt; 
        }

        internal int updateTask(int jobId)
        {
            var t = _repository.GetAll<JobTime>(k=>k.JobId == jobId&&!k.EndTime.HasValue).ToList();
            if (t.Any())
            {
                var tt = t[0];
                tt.EndTime = DateTime.Now;
                _repository.Update(tt);

            }
            else
            {
                JobTime add = new JobTime() { JobId = jobId, StartTime = DateTime.Now };
                _repository.Add(add);
            }

            return 0;
        }
    }
}
