
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TestWEBAPI.Entities;

namespace TestWEBAPI.Repository
{
    public class CollegeRepository<T> : ICollegeRepository<T> where T : class
    {
        private readonly CollegeDB _dbCOntext;
        private DbSet<T> _dbSet;

        public CollegeRepository(CollegeDB dbCOntext)
        {
            _dbCOntext = dbCOntext;
            _dbSet = _dbCOntext.Set<T>();
        }
        public async Task<T> CreateAsync(T dbrecord)
        {
            _dbCOntext.Add(dbrecord);
            await _dbCOntext.SaveChangesAsync();
            return dbrecord;
        }

        public async Task<bool> DeleteAsync(T dbrecord)
        {
            _dbCOntext.Remove(dbrecord);
            await _dbCOntext.SaveChangesAsync();
            return true;
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(Expression<Func<T, bool>> filter,bool useNoTracking=false)
        {
            if (useNoTracking)
                return await _dbSet.AsNoTracking().Where(filter).FirstOrDefaultAsync();
            else
                return await _dbSet.Where(filter).FirstOrDefaultAsync();
        }

        public async Task<T> GetByNameAsync(Expression<Func<T, bool>> filter)
        {
            return await _dbSet.Where(filter).FirstOrDefaultAsync();
        }

        public async Task<T> UpdateAsync(T dbrecord)
        {
            _dbCOntext.Update(dbrecord);
            await _dbCOntext.SaveChangesAsync();
            return dbrecord;
        }
    }
}
