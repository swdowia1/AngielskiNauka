using AngielskiNauka.ModelApi;
using AngielskiNauka.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AngielskiNauka
{
    [Route("api/[controller]")]
    //[Route("api/ang")]
    [ApiController]
    public class angController : ControllerBase
    {
        AaaswswContext _db;
        ConfigGlobal _config;
        public angController(AaaswswContext db, ConfigGlobal config)
        {
            _db = db;
            _config = config;
        }

        [HttpGet]

        public Test Get()
        {
            var result = new Test();

            return result;
        }


        // GET api/<ValuesController>/5
        [HttpGet("{poziom}")]
        public async Task<ActionResult<Test>> Get(int poziom)
        {
            int ilosc = _config.Ile();
            var poland = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTimeOffset.UtcNow, "Europe/Warsaw").ToLocalTime();


            var result = new Test();
            var listastart = _db.Danes.Where(w => w.PoziomId == poziom).OrderBy(j => j.Stan)
                .ThenBy(jj => jj.Data)
                .Take(ilosc).ToList();
            List<int> idlos = listastart.Select(k => k.DaneId).ToList();
            idlos.Losuj();
            //idlos = idlos.Take(ilosc).ToList();


            var lista =
    (from id in idlos
     join k in listastart on id equals k.DaneId
     select
                 new Slowo()
                 {
                     Id = k.DaneId,
                     Ang = k.Ang,
                     Pol = k.Pol,
                     Data = k.Data,
                     Poziom = k.PoziomId
                 }).ToList();
            var ff = classFun.GetSlowos(lista).ToList();
            result.Slowa = ff.ToArray();
            result.Ilosc = ff.Count();
            return new JsonResult(result);

        }

        // POST api/<ValuesController>


        [HttpPost]

        public ActionResult<List<string>> Post([FromBody] Test value)

        {

            var poland = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTimeOffset.UtcNow, "Europe/Warsaw").ToLocalTime();
            DateTime dataTeraz = poland.UtcDateTime.AddHours(1);
            List<int> ok = value.Slowa.Where(k => k.stan == Stan.dobrze).Select(j => j.Id).ToList();
            List<int> zle = value.Slowa.Where(k => k.stan == Stan.zle).Select(j => j.Id).ToList();
            foreach (var item in ok)
            {
                Dane d = _db.Danes.FirstOrDefault(l => l.DaneId == item);
                d.Data = dataTeraz.AddYears(1);
                int stan = d.Stan + 2;
                if (stan > 10)
                    stan = 10;
                d.Stan = stan;
            }
            foreach (var item1 in zle)
            {
                Dane d = _db.Danes.FirstOrDefault(l => l.DaneId == item1);
                int stan = d.Stan - 1;
                if (stan < -10)
                    stan = -10;
                d.Data = dataTeraz.AddMonths(-3);
                d.Stan = stan;
            }
            Stat ss = new Stat()
            {
                Data = dataTeraz,
                Ilosc = ok.Count * (100 / value.Slowa.Length),
                PoziomId = value.Slowa.FirstOrDefault().Poziom,
                Repeat = ""
            };
            if (zle.Any())
            {
                var lista = value.Slowa.Where(j => j.stan == Stan.zle).Select(k => k.Ang + ":" + k.Pol).ToList();

                ss.Repeat = String.Join("||", lista); ;
            }
            _db.Stats.Add(ss);
            _db.SaveChanges();
            if (!zle.Any())
                return new JsonResult(new List<string>() { "zapisano" });
            else
            {
                var dd = value.Slowa.Where(j => j.stan == Stan.zle).Select(k => k.Ang + ":" + k.Pol).ToList();
                return new JsonResult(dd);
            }
        }



        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
