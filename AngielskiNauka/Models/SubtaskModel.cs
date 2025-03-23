namespace AngielskiNauka.Models
{
    public class SubtaskModel
    {
        public int Id { get; set; }
        public int TaskId { get; set; }
        public string Name { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }

        // Nawigacja do zadania
        public TaskModel Task { get; set; }
    }

}