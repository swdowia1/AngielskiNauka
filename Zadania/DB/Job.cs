namespace Zadania.DB
{

    public class Job
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public bool Completed { get; set; }
        public List<JobTime> TaskTimes { get; set; } = new List<JobTime>();
    }

}