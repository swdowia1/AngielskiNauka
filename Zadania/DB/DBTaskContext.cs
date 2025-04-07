using Microsoft.EntityFrameworkCore;

namespace Zadania.DB
{
    public class DBTaskContext: DbContext
    {
        public DBTaskContext()
        {
                
        }
        public DBTaskContext(DbContextOptions<DBTaskContext> options)
       : base(options)
        {
        }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<JobTime> JobTimes { get; set; }
    }
}
