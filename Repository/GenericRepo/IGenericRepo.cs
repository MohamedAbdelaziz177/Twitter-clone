using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Twitter.Repository.GenericRepo
{
    public interface IGenericRepo<T> where T : class
    {
        Task<T?> GetByIdAsync(int id);

        Task<List<T>> GetAllAsync();

        Task InsertAsync(T entity);
        
        Task UpdateAsync(T entity);

        Task DeleteAsync(int id);

        Task<List<T>> GetAsync(Expression<Func<T, bool>>? filter = null, string? icludes = null, bool tracked = false);

    }
}
