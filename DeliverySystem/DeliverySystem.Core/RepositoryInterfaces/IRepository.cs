using System.Linq.Expressions;

namespace DeliverySystem.Core.RepositoryInterfaces
{
    public interface IRepository<T>
    {
        Task InsertAsync(T obj);
        void Update(T obj);
        Task DeleteAsync(int id);
        IQueryable<T> GetAll();
        IQueryable<T> Get(Expression<Func<T, bool>> expression);
        Task<T> GetByIdAsync(int id);
        Task SaveAsync();
    }
}
