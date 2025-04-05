using AngielskiNauka.ModelApi;
using AngielskiNauka.Models;
using AngielskiNauka.Unit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace AngielskiNauka
{

    [Route("api/[controller]")]
    [ApiController]
    public class zadController : ControllerBase
    {
        AngService _service;
        ConfigGlobal _config;
        private readonly IHubContext<TaskHub> _hubContext;

        public zadController(AngService service, ConfigGlobal config, IHubContext<TaskHub> hubContext)
        {
            _service = service;
            _config = config;
            _hubContext = hubContext;
        }

        // Czwarta metoda GET zwracająca listę Job
        [HttpGet("jobs")]
        public async Task<ActionResult<List<JobView>>> Get()
        {
           
            return new JsonResult(_service.Zadania());
        }

        // Czwarta metoda GET zwracająca listę Job
        [HttpPost("addtask")]
        public async Task<ActionResult<int>> addtask([FromBody] string val)
        {
            int wynik = _service.AddTask(val);
            await _hubContext.Clients.All.SendAsync("NewTaskNotification", val, "opis");

            return new JsonResult(wynik);
        }
        // Czwarta metoda GET zwracająca listę Job
        [HttpPost("update")]
        public async Task<ActionResult<int>> update([FromBody] int val)
        {
            int wynik = _service.updateTask(val);
            return new JsonResult(wynik);
        }
    }
   
}
