using AngielskiNauka.ModelApi;
using AngielskiNauka.Models;
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

        
        [HttpPost("update")]
        public async Task<ActionResult<int>> update([FromBody] DaneUpdate dane)
        {
            _service.updateword(dane);
            return new JsonResult(1);
        }
        [HttpPost("update/{id}/{typ}")]
        public async Task<ActionResult<string>> Update(int id,int typ)
        {
            string result=_service.UpdateSlow(id, typ==1);
            return new JsonResult(result);
        }
        
        [HttpGet("getslowa/{poziom}")]
        public async Task<ActionResult<Fiszka>> getslowa(int poziom)
        {

            Fiszka result = _service.LosoweSlowo(poziom);

            return new JsonResult(result);
            
        }
    }
}
