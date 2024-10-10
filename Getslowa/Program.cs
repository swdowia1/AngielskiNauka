using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Getslowa
{
    internal class Program
    {

        static void Main(string[] args)
        {
            //Console.WriteLine("Pobieranie");
            //for (int i = 1; i <= 70; i++)
            //{
            //    DownloadWebPage(i);
            //}
            AnalizaHtml(70);
            Console.WriteLine("nacisnsni klawisz");
            Console.ReadKey(true);
        }

        private static void AnalizaHtml(int v)
        {
            string filename = "C:\\dyskD\\wywal\\angHtml\\ang{0}.html";
            string filtetxt = "C:\\dyskD\\wywal\\angHtml\\angtxt{0}.txt";
            string plik = string.Format(filename, v);
            string Zapiszpliktxt = string.Format(filtetxt, v);
            File.WriteAllText(Zapiszpliktxt, "");
            string[] linie = File.ReadAllLines(plik);
            int pos = 0;

            foreach (var item in linie)
            {
                if (item.Contains("slowko") && item.EndsWith("</a>"))
                {
                    string ang = item;
                    string pol = linie[pos + 3];
                    File.AppendAllText(Zapiszpliktxt, ang + "||" + pol + Environment.NewLine);
                }
                pos++;

            }
        }

        private static void Zapiszstrona(int v)
        {
            string file = @"C:\dyskD\wywal\angHtml\ang{0}.html";
            using (WebClient client = new WebClient()) // WebClient class inherits IDisposable
            {
                client.DownloadFile("https://angielskie-slowka.pl/poziom-rozszerzony,16,kategoria," + v, string.Format(file, v));

                Console.WriteLine("zapisano " + v);
            }

        }
        public static async Task DownloadWebPage(int v)
        {
            string filename = $@"C:\dyskD\wywal\angHtml\ang{v}.html";

            string urlToDownload = "https://angielskie-slowka.pl/poziom-rozszerzony,16,kategoria," + v;

            // Setup the HttpClient
            using (HttpClient httpClient = new HttpClient())
            {
                // Get the webpage asynchronously
                HttpResponseMessage resp = await httpClient.GetAsync(urlToDownload);

                // If we get a 200 response, then save it
                if (resp.IsSuccessStatusCode)
                {
                    Console.WriteLine("Pobrano " + v);

                    // Get the data
                    byte[] data = await resp.Content.ReadAsByteArrayAsync();

                    // Save it to a file
                    FileStream fStream = File.Create(filename);
                    await fStream.WriteAsync(data, 0, data.Length);
                    fStream.Close();

                    Console.WriteLine("zapisano! " + v);
                }
            }
        }
    }
}
