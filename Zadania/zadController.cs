using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Zadania.Models;
using Zadania.Repozytorium;

namespace Zadania
{

    [Route("api/[controller]")]
    [ApiController]
    public class zadController : ControllerBase
    {
        private IRepository _repository;

        public zadController(IRepository repository)
        {
            _repository = repository;
        }

        // Czwarta metoda GET zwracająca listę Job
        [HttpPost("addtask")]
        public async Task<ActionResult<int>> addtask([FromBody] string val)
        {
            Job j = new Job() { Text = val };
            var r = _repository.Add(j);
           

            return new JsonResult(r);
        }
        // Czwarta metoda GET zwracająca listę Job
        [HttpPost("update")]
        public async Task<ActionResult<int>> update([FromBody] int jobId)
        {
            var t = _repository.GetById<Job>(jobId, k => k.JobTimes);
            var jt = t.JobTimes.FirstOrDefault(k => !k.EndTime.HasValue);
            if (jt != null)
            {
                jt.EndTime = classFun.DateNow();
                _repository.Update(jt);
            }
            else
            {
                JobTime add = new JobTime() { JobId = jobId, StartTime = classFun.DateNow() };
                 _repository.Add(add);
            }
            //if (t.Any())
            //{
            //    var tt = t[0];
            //    tt.EndTime = classFun.CurrentTimePoland();
            //    _repository.Update(tt);

            //}
            //else
            //{
            //    JobTime add = new JobTime() { JobId = jobId, StartTime = classFun.CurrentTimePoland() };
            //    _repository.Add(add);
            //}

            return new JsonResult(1);
        }
    }
}
