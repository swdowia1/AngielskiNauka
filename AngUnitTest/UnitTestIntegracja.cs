namespace AngUnitTest
{
    public class UnitTestIntegracja : DBPrawdziwa
    {
        [Fact]
        public void Test1()
        {
            var p = _AngService.GetPoziom(3);
            Assert.Equal(p.Nazwa, "Poziom1");

        }
        [Fact]
        public void AddPoziom()
        {
            string nazwa = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 6);
            var p = _AngService.AddPoziom(nazwa);
            Assert.Equal(p, 1);

        }

    }
}
