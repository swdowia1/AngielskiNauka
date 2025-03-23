namespace AngielskiNauka.Models;

public class TaskModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime? EndTime { get; set; }

    // Relacja jeden-do-wielu
    public List<SubtaskModel> Subtasks { get; set; } = new();
}
