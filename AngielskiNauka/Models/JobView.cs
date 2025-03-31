namespace AngielskiNauka.Models
{
    public class JobView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string TimeJob { get; set; }
        public int TotalMInute { get; set; }
        public List<JobTimeView> JobTime { get; set; }
        /// <summary>
        /// 0 aktualne 1 nie wykonuje
        /// </summary>
        public int Work { get; set; }
    }
}
