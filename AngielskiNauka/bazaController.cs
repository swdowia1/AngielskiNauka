using AngielskiNauka.ModelApi;
using Microsoft.AspNetCore.Mvc;

namespace AngielskiNauka
{
    [Route("api/[controller]")]
    //[Route("api/ang")]
    [ApiController]
    public class bazaController : ControllerBase
    {
        // Czwarta metoda GET zwracająca listę Job
        [HttpPost("update")]
        public async Task<ActionResult<int>> update([FromBody] DaneUpdate dane)
        {



            return new JsonResult(1);
        }
    }
}
