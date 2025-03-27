using AngielskiNauka.Models;
using AngielskiNauka.Unit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AngielskiNauka.Pages
{
    public class JobModel : PageModel
    {
        AngService _service;

        public JobModel(AngService service            )
        {
            _service = service;
        }

        [BindProperty]
        public string NewTaskText { get; set; }

        public IList<Job> Tasks { get; set; }

        public async Task OnGetAsync()
        {
            Tasks = _service.Zadania();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            //if (!string.IsNullOrEmpty(NewTaskText))
            //{
            //    var newTask = new Task { Text = NewTaskText, Completed = false };
            //    _context.Tasks.Add(newTask);
            //    await _context.SaveChangesAsync();
            //}

            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostMarkCompletedAsync(int taskId)
        {
            //var task = await _context.Tasks.FindAsync(taskId);
            //if (task != null)
            //{
            //    task.Completed = true;
            //    await _context.SaveChangesAsync();
            //}

            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int taskId)
        {
            //var task = await _context.Tasks.FindAsync(taskId);
            //if (task != null)
            //{
            //    _context.Tasks.Remove(task);
            //    await _context.SaveChangesAsync();
            //}

            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostAddTimeAsync(int taskId)
        {
            //var taskTime = new TaskTime
            //{
            //    TaskId = taskId,
            //    StartTime = DateTime.Now,
            //    EndTime = DateTime.Now.AddHours(1) // Przyk³adowy czas
            //};
            //_context.TaskTimes.Add(taskTime);
            //await _context.SaveChangesAsync();

            return RedirectToPage();
        }
    }
}
