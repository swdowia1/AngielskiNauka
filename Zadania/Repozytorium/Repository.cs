using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Zadania.DB;


namespace Zadania.Repozytorium
{
    public class Repository : IRepository
    {
        private readonly DBTaskContext _db;

        public Repository(DBTaskContext db)
        {
            _db = db;
        }
        public int Add<T>(T entity) where T : class
        {
            int result;
            _db.Set<T>().Add(entity);
            SaveChanges();
            // Retrieve the primary key property name using metadata from the model
            var keyProperty = _db.Model.FindEntityType(typeof(T))
                .FindPrimaryKey()
                .Properties
                .FirstOrDefault();

            // Get the value of the primary key
            var primaryKeyValue = keyProperty != null ? keyProperty.PropertyInfo.GetValue(entity) : null;

            var propertyType = keyProperty?.ClrType;


            result = (int)primaryKeyValue;

            return result;
        }

        public void Update<T>(T entity) where T : class
        {
            _db.Set<T>().Update(entity);
            SaveChanges();
        }

        public void Delete<T>(int id) where T : class
        {
            var entity = _db.Set<T>().Find(id);
            if (entity != null)
            {
                _db.Set<T>().Remove(entity);
            }
        }
        public async Task<int> RunStoredProcedureNonQuery(string storedProcedure, Dictionary<string, object> parameters)
        {
            try
            {
                string joinedKeys = string.Join(",", parameters.Keys);
                // Tworzymy tablicę parametrów SQL z dictionary
                var sqlParameters = parameters.Select(p => new SqlParameter(p.Key, p.Value)).ToArray();
                // await _repository.RunStoredProcedureNonQuery("EXEC [dbo].[AddStat] @oklist, @zlelist", parameters);
                // Wywołanie procedury składowanej z parametrami
                int result = _db.Database.ExecuteSqlRawAsync("EXEC " + storedProcedure + " " + joinedKeys, sqlParameters).Result;

                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Błąd SQL: {ex.Message}");
                return 0;
            }
        }
        public int SaveChanges()
        {
            return _db.SaveChanges();
        }


        public IEnumerable<T> GetAllIncluding<T>(params Expression<Func<T, object>>[] includes) where T : class
        {
            IQueryable<T> query = _db.Set<T>();
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            return query.ToList();
        }

        public T GetById<T>(int id, params Expression<Func<T, object>>[] includes) where T : class
        {
            IQueryable<T> query = _db.Set<T>();
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            return query.FirstOrDefault(e => EF.Property<int>(e, "Id") == id);
        }
    }
}
