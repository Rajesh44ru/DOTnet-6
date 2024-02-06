using System.Linq.Expressions;
using TestWEBAPI.Entities;

namespace TestWEBAPI.Repository
{
    public interface ICollegeRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync();
       // Task<T> GetByIdAsync(int id,bool useTracking=false);
        Task<T> GetByIdAsync(Expression<Func<T, bool>> filter, bool useNoTracking = false);
        Task<T> GetByNameAsync(Expression<Func<T, bool>> filter);
        Task<T> CreateAsync(T dbrecord);
        Task<T> UpdateAsync(T dbrecord);
        Task<bool> DeleteAsync(T record);
    }
}
