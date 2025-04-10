using AngielskiNauka.ModelApi;
using AngielskiNauka.Unit;
using Microsoft.AspNetCore.Mvc;

namespace AngielskiNauka
{
    [Route("api/[controller]")]
    //[Route("api/ang")]
    [ApiController]
    public class bazaController : ControllerBase
    {
        AngService _service;

        public bazaController(AngService service)
        {
            _service = service;
        }

        // Czwarta metoda GET zwracająca listę Job
        [HttpPost("update")]
        public async Task<ActionResult<int>> update([FromBody] DaneUpdate dane)
        {
           
            classFun.opuznienie(3);
            _service.updateword(dane);
           

            return new JsonResult(1);
        }
    }
}
