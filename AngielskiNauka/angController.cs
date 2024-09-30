using AngielskiNauka.ModelApi;
using AngielskiNauka.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AngielskiNauka
{
    [Route("api/[controller]")]
    [ApiController]
    public class angController : ControllerBase
    {
        AaaswswContext _db;

        public angController(AaaswswContext db)
        {
            _db = db;
        }

        [HttpGet]

        public Test Get()
        {
            var result = new Test();
            
            return result;
        }
        

        // GET api/<ValuesController>/5
        [HttpGet("{poziom}")]
        public  async Task<ActionResult<Test>> Get(string poziom)
        {
           var result = new Test();
            var listastart = _db.Danes.Where(w => w.Poziom.Nazwa == poziom).OrderBy(j => j.Data).Take(40).ToList();
            List<int> idlos = listastart.Select(k => k.DaneId).ToList();
            idlos.Losuj();
            idlos = idlos.Take(20).ToList();


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
            return new JsonResult(result);
           
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
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
