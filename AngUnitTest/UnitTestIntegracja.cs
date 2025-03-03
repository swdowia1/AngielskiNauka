namespace AngUnitTest
{
    public class UnitTestIntegracja : DBPrawdziwa
    {
        [Fact]
        public void GetPoziomTest()
        {
            // Act
            var p = _AngService.GetPoziom(3);

            // Assert
            Assert.Equal(p.Nazwa, "Poziom1");

        }
        [Fact]
        public void AddPoziom()
        {
            // Act
            string nazwa = classFun.GetTextRandom();
            var p = _AngService.AddPoziom(nazwa);

            // Assert
            var testdb = _db.Pozioms.OrderBy(j => j.PoziomId).Last();
            Assert.True(testdb.PoziomId == p.KeyInt);

        }

    }
}
