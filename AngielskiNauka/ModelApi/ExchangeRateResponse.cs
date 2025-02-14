namespace AngielskiNauka.ModelApi
{
    public class ExchangeRateResponse
    {
        public List<Rate> rates { get; set; }
    }

    public class Rate
    {
        public string effectiveDate { get; set; }
        public double mid { get; set; }
    }
}
