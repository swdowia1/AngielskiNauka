using AngielskiNauka.Unit;
using Microsoft.AspNetCore.Mvc;

namespace AngielskiNauka
{
    [Route("api/[controller]")]
    //[Route("api/ang")]
    [ApiController]
    public class gitController : ControllerBase
    {
        private readonly TaskService _taskService;

        public gitController(TaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpPost]

        public ActionResult<string> Post([FromBody] string value)

        {
            _taskService.RegisterTaskAsync(value);
            return "ok";
        }

        /*
         [HttpPost]

        public ActionResult<string> Post([FromBody] string value)

        {
            string url = "https://api.github.com/repos/swdowia1/AngielskiNauka/actions/runs/" + value;
            string token = "";  // Replace with a valid token

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github+json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                client.DefaultRequestHeaders.UserAgent.TryParseAdd("CSharpApp"); // GitHub requires a User-Agent header
                client.DefaultRequestHeaders.Add("X-GitHub-Api-Version", "2022-11-28");

                HttpResponseMessage response = client.DeleteAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {

                    return new JsonResult("usnieto " + value);
                }
                else
                {
                    return "err";
                }
            }
            return "ok";
        }
         */

    }

    /*
      [Route("api/[controller]")]
    //[Route("api/ang")]
    [ApiController]
    public class angController : ControllerBase
    {
     */
}
