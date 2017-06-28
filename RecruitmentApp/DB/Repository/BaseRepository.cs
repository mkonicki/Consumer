using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RecruitmentApp.Entities;

namespace RecruitmentApp.DB.Repository
{
    public interface IBaseRepository<T> where T : class, IEntity
    {
        Task<bool> Add(T entity);
        IList<T> GetAll();
        Task<bool> Update(T entity);
        Task<int> SaveChangesAsync();
    }

    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class, IEntity
    {
        private readonly DbContext _context;
        protected DbSet<T> Data;

        protected BaseRepository(DbContext context)
        {
            _context = context;
            Data = _context.Set<T>();
        }

        public virtual async Task<bool> Add(T entity)
        {
            _context.Add(entity);
            return await SaveChangesAsync() > 0;
        }

        public virtual IList<T> GetAll()
        {
            return Data.AsQueryable().ToList();
        }

        public virtual async Task<bool> Update(T entity)
        {
            _context.Update(entity);
            return await SaveChangesAsync() > 0;
        }

        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}