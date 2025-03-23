
using AngielskiNauka.Models;

namespace AngielskiNauka.Unit
{


    public class TaskService
    {
        IRepository _repository;

        public TaskService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task CompleteTaskAsync(int taskId)
        {
            TaskModel task = _repository.GetById<TaskModel>(taskId);
            if (task != null)
            {
                task.EndTime = DateTime.Now;
                _repository.Update(task);
            }


        }

        public Task<List<TaskModel>> GetTasksAsync()
        {

            return _repository.GetAll<TaskModel>();

        }

        public Task<int> RegisterTaskAsync(string name)
        {
            var task = new TaskModel { Name = name, StartTime = DateTime.UtcNow };
            var res = _repository.Add(task);

            return Task.FromResult(res.KeyInt);
        }
    }
}
