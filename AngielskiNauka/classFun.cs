using AngielskiNauka.ModelApi;
using System.Security.Cryptography;

namespace AngielskiNauka
{
    public static class classFun
    {
        public static DateTime GetRandomDate(int minYear = 2025, int maxYear = 2099)
        {
            Random random = new Random();
            var year = random.Next(minYear, maxYear);
            var month = random.Next(1, 12);
            var noOfDaysInMonth = DateTime.DaysInMonth(year, month);
            var day = random.Next(1, noOfDaysInMonth);

            return new DateTime(year, month, day);
        }
        private static string[] LosujOdpiwedzi(Slowo s, List<Slowo> result)
        {
            List<string> odp = new List<string>();
            odp.Add(s.Pol);
            odp.AddRange(result.Where(k => k.Id > s.Id && k.Ang != s.Ang).Take(3).Select(l => l.Pol).ToList());
            int ilosc = 4 - odp.Count;
            if (ilosc > 0)
            {
                odp.AddRange(result.Where(j => j.Ang != s.Ang).Take(ilosc).Select(p => p.Pol).ToList());
            }
            odp.Losuj();
            return odp.ToArray();
        }
        public static void Losuj<T>(this IList<T> list)
        {
            RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
            int n = list.Count;
            while (n > 1)
            {
                byte[] box = new byte[1];
                do provider.GetBytes(box);
                while (!(box[0] < n * (Byte.MaxValue / n)));
                int k = (box[0] % n);
                n--;
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        public static List<Slowo> GetSlowos(List<Slowo> baza)
        {
            List<Slowo> result = baza.OrderBy(j => j.Data).OrderBy(l => l.Id).ToList();
            foreach (Slowo s in result)
            {

                s.Odpowiedzi = LosujOdpiwedzi(s, result);

            }

            return result;

        }
    }
}
