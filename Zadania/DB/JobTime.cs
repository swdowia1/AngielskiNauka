namespace Zadania.DB
{

    public class JobTime
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public int JobId { get; set; }
        public Job Job { get; set; }
    }
}