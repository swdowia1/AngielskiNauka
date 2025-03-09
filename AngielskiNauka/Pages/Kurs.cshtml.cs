using AngielskiNauka.ModelApi;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace AngielskiNauka.Pages
{
    public class KursModel : PageModel
    {
        public int poziom;
        public string waluta;
        public ExchangeRateResponse exchangeRateResponse;
        public async void OnGet(int? id, string? wal)
        {
            exchangeRateResponse = new ExchangeRateResponse() { rates = new List<Rate>() };
            poziom = id ?? 100;
            if (wal == null)
            {
                waluta = "USD";
            }
            else
                waluta = wal;
            exchangeRateResponse = LoadCurrencyData(poziom, waluta).Result;


        }
        private async Task<ExchangeRateResponse> LoadCurrencyData(int zakres, string wal = "USD")
        {
            string apiUrl = $"https://api.nbp.pl/api/exchangerates/rates/c/{wal}/last/{zakres}/?format=json";
            try
            {
                using HttpClient client = new HttpClient();
                string jsonResponse = await client.GetStringAsync(apiUrl);
                return JsonSerializer.Deserialize<ExchangeRateResponse>(jsonResponse);


            }
            catch (Exception ex)
            {

            }
            return null;
        }
    }
}
