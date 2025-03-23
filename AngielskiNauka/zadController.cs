using AngielskiNauka.Unit;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AngielskiNauka
{
    [Route("api/[controller]")]
    //[Route("api/ang")]
    [ApiController]
    public class zadController : ControllerBase
    {
        private readonly TaskService _taskService;

        public zadController(TaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpPost]

        public ActionResult<List<string>> Post([FromBody] string taskName)
        {
            return null;
        }






    }
}
