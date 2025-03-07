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
            Assert.Equal(p.Nazwa, "Stas");

        }


    }
}
