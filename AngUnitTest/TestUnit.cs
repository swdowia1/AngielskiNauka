using AngielskiNauka.Models;
using AngielskiNauka.Unit;
using Moq;
using System.Text;

namespace AngUnitTest
{
    public class TestUnit
    {
        public readonly AngService _AngService;
        public readonly Mock<IRepository> _mockRepository;
        public readonly Mock<IFunVMS> _mockIFunVMS;
        public TestUnit()
        {
            //
            _mockRepository = new Mock<IRepository>();
            _mockIFunVMS = new Mock<IFunVMS>();
            _mockIFunVMS.Setup(f => f.GetDataCacheOrder()).Returns(new List<string>() { "a", "sss", "ddd" });
            _mockIFunVMS.Setup(s => s.KeyTransalate(It.IsAny<string>())).Returns((string key) => key);
            _mockIFunVMS.Setup(m => m.SendMail());
            //_mockIFunVMS.Setup(m => m.SendMail()).Callback(() =>
            //{
            //    File.AppendAllText(@"C:\dyskD\wywal\MOCK\mail_log.txt", $"{DateTime.Now}: SendMail called{Environment.NewLine}");
            //});
            _mockRepository.Setup(db => db.GetById<Poziom>(It.IsAny<int>())).Returns(new Poziom() { PoziomId = 1, Nazwa = "test" });
            _AngService = new AngService(_mockRepository.Object, _mockIFunVMS.Object,null);

        }
        [Fact]
        public void Test1()
        {
            var p = _AngService.GetPoziom(1);
            Assert.Equal(p.Nazwa, "test");

        }
        [Fact]
        public  async void ang()
        {
            string text = "splendid";
            string sourceLang = "en";
            string targetLang = "pl";

            string url = $"https://api.mymemory.translated.net/get?q={Uri.EscapeDataString(text)}&langpair={sourceLang}|{targetLang}";

            using (HttpClient client = new HttpClient())
            {
                string result = await client.GetStringAsync(url);
                Console.WriteLine("Wynik t³umaczenia:");
                Console.WriteLine(result);
            }
            Assert.Equal(1,1);
        }

        [Fact]
        public void FakturaTest()
        {
            //pierwszy to wunik reszta skladniki
            List<decimal> dane = new List<decimal>() { 2, 2, 0.139m, 1, 1, 1 };
            decimal wartoscoczekiwana = 7.13m;
            var p = _AngService.Faktura(dane);
            Assert.Equal(p, wartoscoczekiwana);

        }
        //LogikaBiznesowa
        [Fact]
        public void LogikaBiznesowaTest()
        {
            // dla listy zamowieni "a", "sss", "ddd" jesli nie zaczyna sie na "a" to nie wysylaj
            _AngService.LogikaBiznesowa();
            _mockIFunVMS.Verify
                (m => m.SendMail(), Times.Exactly(2));

        }

        [Theory]
        [InlineData(0, null, 0, 9, "", "nie jest z onninen i bez odpowiedzi")]
        [InlineData(1, null, 3, 9, "order-status-transport97", "Wys³ane do dostawcy")]
        [InlineData(1, null, 2, 9, "", "Wys³ane do dostawcy")]
        [InlineData(1, null, null, 9, "", "Wys³ane do dostawcy")]
        [InlineData(1, 0, 0, 9, "order-status-transport99", "")]
        [InlineData(1, 1, 3, 9, "order-status-transport1", "")]
        [InlineData(1, 1, 1, 9, "order-status-transport98", "")]
        [InlineData(1, 1, 1, 99, "", "")]
        [InlineData(0, 3, 1, 9, "order-status-transport3", "")]
        public void StatusOrder_test(int isonninenpl, int? max_realization, int? stsQue, int statussap, string expect, string opis)
        {
            var gg = _AngService.StatusOrder(isonninenpl, max_realization, stsQue, statussap, isZDS: true);

            Assert.Equal(expect, gg);
        }

        [Theory]
        [InlineData(1, null, 3, 9, "order-status-transport97", "Wys³ane do dostawcy")]
        public void StatusOrder_test2(int isonninenpl, int? max_realization, int? stsQue, int statussap, string expect, string opis)
        {
            var gg = _AngService.StatusOrder(isonninenpl, max_realization, stsQue, statussap, isZDS: true);

            Assert.Equal(expect, gg);
        }

    }
}
