﻿namespace AngielskiNauka.ModelApi
{
    public class ExchangeRateResponse
    {
        public List<Rate> rates { get; set; }
    }

    public class Rate
    {
        public string effectiveDate { get; set; }
        public double bid { get; set; }
        public double ask { get; set; }
    }
}
