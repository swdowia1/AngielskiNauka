namespace AngUnitTest
{
    public class TestIntegration : DBPrawdziwa
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
