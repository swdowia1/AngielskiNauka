namespace AngielskiNauka.Models
{
    public class JobTimeView
    {
        public JobTimeView(DateTime start, DateTime? end)
        {
            Start = start;
            End = end;
            Minute = end.HasValue ? (int)(end.Value - start).TotalMinutes : 0;
        }

        public DateTime Start { get; set; }
        public DateTime? End { get; set; }
        public int Minute { get; set; }

    }
}