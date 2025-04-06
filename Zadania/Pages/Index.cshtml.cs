using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using Zadania.Models;
using Zadania.Repozytorium;
using Zadania.VM;

namespace Zadania.Pages
{

    public class IndexModel : PageModel
    {
        private IRepository _repository;
       public  List<JobView> jobs;
        public int JobId;
        public int TotalMinute;


        public IndexModel(IRepository repository)
        {
            _repository = repository;
        }

        public void OnGet()
        {
            var lista = _repository.GetAllIncluding<Job>(j => j.JobTimes).ToList();


            jobs = lista.Select(k => new JobView()
            {
                Id = k.Id,
                Name = k.Text,
                JobTime = k.JobTimes.Select(j => new JobTimeView(j.StartTime, j.EndTime)).ToList()

            }).ToList();

            foreach (var item in jobs)
            {
                item.TimeJob = classFun.TimeHourMinute(item.JobTime.Sum(k => k.Minute));
                item.TotalMInute = item.JobTime.Sum(k => k.Minute);
                item.Work = item.JobTime.Any(k => !k.End.HasValue) == true ? 1 : 0;
            }
            var t = jobs.FirstOrDefault(k => k.Work == 1);
            if (t != null)
            {
                JobId = t.Id;
                TotalMinute = t.TotalMInute;
            }
        }
    }
}
