using AngielskiNauka.ModelApi;
using AngielskiNauka.Models;
using AngielskiNauka.Unit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace AngielskiNauka
{

    [Route("api/[controller]")]
    [ApiController]
    public class zadController : ControllerBase
    {
        AngService _service;
        ConfigGlobal _config;

        public zadController(AngService service, ConfigGlobal config)
        {
            _service = service;
            _config = config;
        }

        // Czwarta metoda GET zwracająca listę Job
        [HttpGet("jobs")]
        public async Task<ActionResult<List<JobView>>> Get()
        {
            List<JobView> jobs = _service.Zadania().Select(k => new JobView() { Id = k.Id, Name = k.Text }).ToList(); // Zakładając, że AngService ma taką metodę
            return new JsonResult(jobs);
        }
    }
   
}
