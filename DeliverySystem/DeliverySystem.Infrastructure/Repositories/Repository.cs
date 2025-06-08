
using DeliverySystem.Core.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DeliverySystem.Infrastructure.Repositories
{
     public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DeliveryDbContext context;
        protected DbSet<T> dbSet;

        public Repository(DeliveryDbContext context)
        {
            this.context = context;
            dbSet = context.Set<T>();
        }
        public async Task InsertAsync(T obj)
        {
            await dbSet.AddAsync(obj);
        }
        public void Update(T obj)
        {
            dbSet.Update(obj);
        }
        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                dbSet.Remove(entity);
            }
        }
        public IQueryable<T> GetAll()
        {
            return dbSet;
        }
        public async Task<T> GetByIdAsync(int id)
        {
            return await dbSet.FindAsync(id);
        }
        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }
        public IQueryable<T> Get(Expression<Func<T, bool>> expression)
        {
            return dbSet.Where(expression);
        }
    }
}
