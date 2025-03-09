using AngielskiNauka.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AngielskiNauka.Unit
{
    public class Repository : IRepository
    {
        private readonly AaaswswContext _db;

        public Repository(AaaswswContext db)
        {
            _db = db;
        }

        public IEnumerable<T> GetAll<T>(Expression<Func<T, bool>> predicate) where T : class
        {

            return _db.Set<T>().Where(predicate).ToList();
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

        public T GetById<T>(int id) where T : class
        {
            return _db.Set<T>().Find(id);
        }
        public T GetById<T>(long id) where T : class
        {
            return _db.Set<T>().Find(id);
        }

        public T GetByIdIncluding<T>(int id, params Expression<Func<T, object>>[] includes) where T : class
        {
            IQueryable<T> query = _db.Set<T>();
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            return query.FirstOrDefault(e => EF.Property<int>(e, "Id") == id);
        }
        public T GetByIdIncluding<T>(long id, params Expression<Func<T, object>>[] includes) where T : class
        {
            IQueryable<T> query = _db.Set<T>();
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            return query.FirstOrDefault(e => EF.Property<int>(e, "Id") == id);
        }
        public AddResult Add<T>(T entity) where T : class
        {
            AddResult result = new AddResult();
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

            if (propertyType == typeof(int))
            {
                result.KeyInt = (int)primaryKeyValue;
            }
            else if (propertyType == typeof(long))
            {
                result.KeyLong = (long)primaryKeyValue;
            }
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

        public bool Any<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return _db.Set<T>().Any(predicate);
        }

        public T GetObjectByWhere<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return _db.Set<T>().FirstOrDefault(predicate);
        }

        public void Delete<T>(long id) where T : class
        {
            var entity = _db.Set<T>().Find(id);
            if (entity != null)
            {
                _db.Set<T>().Remove(entity);
                SaveChanges();
            }

        }

        public void Delete<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            var entity = _db.Set<T>().FirstOrDefault(predicate);
            if (entity != null)
            {
                _db.Set<T>().Remove(entity);
                SaveChanges();
            }

        }

        //   void Delete<T>(Expression<Func<T, bool>> predicate) where T : class;
    }
}
