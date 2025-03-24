using AngielskiNauka.ModelApi;
using AngielskiNauka.Unit;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AngielskiNauka
{
    [Route("api/[controller]")]
    //[Route("api/ang")]
    [ApiController]
    public class angController : ControllerBase
    {
        AngService _service;
        ConfigGlobal _config;

        public angController(AngService service, ConfigGlobal config)
        {
            _service = service;
            _config = config;

        }



        // GET api/<ValuesController>/5
        [HttpGet("{poziom}")]
        public async Task<ActionResult<Test>> Get(int poziom)
        {
            // _RabbitMqService.SendMessage("poziom" + poziom);
            int ilosc = _config.Ile();
            var poland = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTimeOffset.UtcNow, "Europe/Warsaw").ToLocalTime();


            var result = new Test();

            var listastart = _service.DaneNauka(poziom, ilosc);
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
            int PoziomId = value.Slowa.FirstOrDefault().Poziom;

            var poland = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTimeOffset.UtcNow, "Europe/Warsaw").ToLocalTime();
            DateTime dataTeraz = poland.UtcDateTime.AddHours(1);
            List<int> ok = value.Slowa.Where(k => k.stan == Stan.dobrze).Select(j => j.Id).ToList();
            string resultOK = string.Join(',', value.Slowa.Where(k => k.stan == Stan.dobrze).Select(j => j.Id));
            string resultZLE = string.Join(',', value.Slowa.Where(k => k.stan == Stan.zle).Select(j => j.Id));



            _service.AddStat(resultOK, resultZLE, PoziomId);
            List<int> zle = value.Slowa.Where(k => k.stan == Stan.zle).Select(j => j.Id).ToList();


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
