namespace AngielskiNauka.Models;

//public class TaskModel
//{
//    public int Id { get; set; }
//    public string Name { get; set; }
//    public DateTime StartTime { get; set; }
//    public DateTime? EndTime { get; set; }

//    // Relacja jeden-do-wielu
//    public List<SubtaskModel> Subtasks { get; set; } = new();
//}


public class Job
{
    public int Id { get; set; }
    public string Text { get; set; }
    public bool Completed { get; set; }
    public List<JobTime> TaskTimes { get; set; } = new List<JobTime>();
}

public class JobTime
{
    public int Id { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime? EndTime { get; set; }
    public int JobId { get; set; }
    public Job Job { get; set; }
}
