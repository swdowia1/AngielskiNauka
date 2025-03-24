using AngielskiNauka.Models;
using System.Linq.Expressions;

namespace AngielskiNauka.Unit
{
    public interface IRepository
    {
        IEnumerable<T> GetAll<T>(Expression<Func<T, bool>> predicate) where T : class;
        IEnumerable<T> GetAll<T>(
    Expression<Func<T, bool>> predicate,
    Expression<Func<T, object>> orderBy = null,
    bool descending = false,
    int? take = null)
    where T : class;
        Task<List<T>> GetAll<T>() where T : class;
        IEnumerable<T> GetAllIncluding<T>(params Expression<Func<T, object>>[] includes) where T : class;
        T GetById<T>(int id) where T : class;

        T GetObjectByWhere<T>(Expression<Func<T, bool>> predicate) where T : class;
        T GetById<T>(long id) where T : class;
        T GetByIdIncluding<T>(int id, params Expression<Func<T, object>>[] includes) where T : class;

        T GetByIdIncluding<T>(long id, params Expression<Func<T, object>>[] includes) where T : class;
        AddResult Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(int id) where T : class;
        void Delete<T>(long id) where T : class;
        void Delete<T>(Expression<Func<T, bool>> predicate) where T : class;
        bool Any<T>(Expression<Func<T, bool>> predicate) where T : class;
        int SaveChanges();
        Task<int> RunStoredProcedureNonQuery(string storedProcedure, Dictionary<string, object> parameters);
    }
}
