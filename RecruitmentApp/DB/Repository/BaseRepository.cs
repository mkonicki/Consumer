using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RecruitmentApp.Entities;

namespace RecruitmentApp.DB.Repository
{
    public interface IBaseRepository<in T> where T : class, IEntity
    {
        Task<bool> Add(T entity);
    }

    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class, IEntity
    {
        private readonly DbContext _context;

        protected BaseRepository(DbContext context)
        {
            _context = context;
        }

        public async Task<bool> Add(T entity)
        {
            _context.Add(entity);
            return await _context.SaveChangesAsync() > 0;
           
        }
    }
}