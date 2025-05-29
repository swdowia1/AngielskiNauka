
using AngielskiNauka.ModelApi;
using AngielskiNauka.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Linq.Expressions;
using System.Xml;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AngielskiNauka.Unit
{
    public class AngService
    {
        IRepository _repository;

        private readonly ILogger<AngService> _logger; // Add a logger field

        public AngService(IRepository repository ,ILogger<AngService> logger)
        {
            _repository = repository;
        
            _logger = logger;
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
        public int Ile()
        {

            return _repository.GetById<Ustawienia>(1).Ile;
        }


        public decimal Faktura(List<decimal> dane)
        {

            return dane.Sum(k => (Math.Floor(k * 100) / 100));
        }

        public List<Dane> DaneFiszka(int id)
        {
            return _repository.GetAll<Dane>(k => k.PoziomId == id).OrderBy(k => k.Stan).ToList();
        }



        public List<Dane> DaneNauka(int id, int ilosc = 20)
        {
            try
            {


                return _repository.GetAll<Dane>(
                w => w.PoziomId == id,
           new List<Expression<Func<Dane, object>>>
    {
        x => x.Stan,
        x => x.Data
    },
           descending: false,
           take: ilosc).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError("DaneNauka " + ex.Message);
                return null;
            }
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

      
        public int AddTask(string val)
        {
            Job j = new Job() { Text = val };
            var r = _repository.Add(j);
            return r.KeyInt;
        }

        public async void DeleteTask(int val)
        {

            var parameters = classFun.CreatePrameter("taskid", val);
            await _repository.RunStoredProcedureNonQuery("[dbo].[deletejob]", parameters);


        }
        internal int updateTask(int jobId)
        {
            var t = _repository.GetAll<JobTime>(k => k.JobId == jobId && !k.EndTime.HasValue).ToList();
            if (t.Any())
            {
                var tt = t[0];
                tt.EndTime = classFun.CurrentTimePoland();
                _repository.Update(tt);

            }
            else
            {
                JobTime add = new JobTime() { JobId = jobId, StartTime = classFun.CurrentTimePoland() };
                _repository.Add(add);
            }

            return 0;
        }

        internal void updateword(DaneUpdate dane)
        {
            Dane d = _repository.GetById<Dane>(dane.Id);
            d.Ang = dane.Ang;
            d.Pol = dane.Pol;
            _repository.Update(d);
        }

        internal async void DeleteLevel(int level)
        {
            var parameters = new Dictionary<string, object>
            {
    { "@poziomid", level },  // Zakładając, że oklist to ciąg wartości

};
            await _repository.RunStoredProcedureNonQuery("[dbo].[DeleteDane]", parameters);

        }

        internal async void ResetLevel(int level)
        {
            var parameters = new Dictionary<string, object>
            {
    { "@poziomid", level },  // Zakładając, że oklist to ciąg wartości

};
            await _repository.RunStoredProcedureNonQuery("[dbo].[RandomTimeSet]", parameters);
        }

        internal void UpdateIle(int ile)
        {
            Ustawienia d = _repository.GetById<Ustawienia>(1);
            d.Ile = ile;
            _repository.Update(d);
        }
    }
}
