﻿namespace Zadania.VM
{
    public class JobTimeView
    {
        public JobTimeView(DateTime start, DateTime? end)
        {
            Start = start;
            End = end;
            if (end.HasValue)
                Minute = (int)(end.Value - start).TotalMinutes;
            else
            {
                Minute = (int)(classFun.DateNow()- start).TotalMinutes;
            }

        }

        public DateTime Start { get; set; }
        public DateTime? End { get; set; }
        public int Minute { get; set; }

    }
}