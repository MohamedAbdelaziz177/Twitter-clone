using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Twitter.Data;

namespace Twitter.Repository.GenericRepo
{
    public class GenericRepo<T> : IGenericRepo<T> where T : class
    {
        private readonly AppDbContext con;
        private readonly DbSet<T> dbSet;

        public GenericRepo(AppDbContext con)
        {
            this.con = con;
            dbSet = con.Set<T>();
        }

        public async Task DeleteAsync(int id)
        {
            T? entity = await dbSet.FindAsync(id);

            dbSet.Remove(entity);

            await con.SaveChangesAsync();

        }

        public async Task<List<T>> GetAllAsync()
        {
            return await dbSet.ToListAsync();
        }

        public async Task<List<T>> GetAsync(Expression<Func<T, bool>>? filter = null, string? icludes = null, bool tracked = false)
        {
            IQueryable<T> query = dbSet;

            if (filter != null)
                query = query.Where(filter);

            if(!tracked)
                query = query.AsNoTracking();

            if (icludes != null)
                foreach (var ic in icludes.Split(','))
                    query.Include(ic);

            return await query.ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await dbSet.FindAsync(id);
        }

        public async Task InsertAsync(T entity)
        {
            await dbSet.AddAsync(entity);
            await con.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            dbSet.Update(entity);
            await con.SaveChangesAsync();
        }

        
    }
}
