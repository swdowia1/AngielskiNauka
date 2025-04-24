using System.Linq.Expressions;

namespace Zadania.Repozytorium
{
    /// <summary>
    /// klasa zadania
    /// </summary>
    public interface IRepository
    {
        IEnumerable<T> GetAllIncluding<T>(params Expression<Func<T, object>>[] includes) where T : class;
    

        T GetById<T>(int id, params Expression<Func<T, object>>[] includes) where T : class;

        int Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(int id) where T : class;
        Task<int> RunStoredProcedureNonQuery(string storedProcedure, Dictionary<string, object> parameters);

    }
}
