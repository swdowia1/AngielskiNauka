using AngielskiNauka.Models;
using AngielskiNauka.Unit;
using Moq;

namespace AngUnitTest
{
    public class UnitTest1
    {
        public readonly AngService _AngService;
        public readonly Mock<IRepository> _mockRepository;
        public readonly Mock<IFunVMS> _mockIFunVMS;
        public UnitTest1()
        {
            _mockRepository = new Mock<IRepository>();
            _mockIFunVMS = new Mock<IFunVMS>();
            _mockIFunVMS.Setup(f => f.GetDataCacheOrder()).Returns(new List<string>() { "a", "sss", "ddd" });
            _mockIFunVMS.Setup(m => m.SendMail());
            _mockRepository.Setup(db => db.GetById<Poziom>(It.IsAny<int>())).Returns(new Poziom() { PoziomId = 1, Nazwa = "test" });
            _AngService = new AngService(_mockRepository.Object, _mockIFunVMS.Object);

        }
        [Fact]
        public void Test1()
        {
            var p = _AngService.GetPoziom(1);
            Assert.Equal(p.Nazwa, "test");

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
            _AngService.LogikaBiznesowa();
            _mockIFunVMS.Verify
                (m => m.SendMail(), Times.Exactly(2));

        }
    }
}