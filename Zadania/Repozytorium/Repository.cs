using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Zadania.Models;

namespace Zadania.Repozytorium
{
    public class Repository : IRepository
    {
        private readonly AaaonninenContext _db;

        public Repository(AaaonninenContext db)
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
