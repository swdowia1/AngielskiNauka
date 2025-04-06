using AngielskiNauka.Models;
using AngielskiNauka.Unit;
using Microsoft.EntityFrameworkCore;

namespace AngUnitTest
{
    public class DBPrawdziwa
    {
        public readonly AngService _AngService;
        public readonly AaaswswContext _db;

        public DBPrawdziwa()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<AaaswswContext>()
            .UseSqlServer("workstation id = aaaswsw.mssql.somee.com; packet size = 4096; user id = swdowia1_SQLLogin_2; pwd = kr62j5x3px; data source = aaaswsw.mssql.somee.com; persist security info = False; initial catalog = aaaswsw; TrustServerCertificate = True")
            .Options;

            _db = new AaaswswContext(options);
            _AngService = new AngService(new Repository(_db), new FunVMS(),null);
        }
    }
}
